using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player2D : MonoBehaviour
{
    private Rigidbody2D _rigidbody;// 刚体
    private Animator animator;// 动画器
    private ConstantForce2D downForce;// 恒力
    public GameObject die;

    private GameObject[] windArea;

    [HideInInspector]
    public int colCount;


    [HideInInspector]
    public Ctrl ctrl;

    [HideInInspector]
    public PlayerData playerData;

    [Header("基本参数")]
    public float moveSpeed;// 玩家移动速度
    public float climbSpeed;// 爬墙速度
    public float gravityScale;// 重力
    private float horizontalMove;// 水平移动轴
    private float verticalMove;// 竖直移动轴
    public bool isRun;// 是否在跑步
    public bool isGround;// 是否在地面上
    public bool isWall;// 是否在墙上
    private bool canWall = true;
    public bool wallGrab;// 是否准备爬墙
    public bool canSave=false;// 是否可以保存
    public Transform groundCheck;
    public LayerMask ground;
    public Transform wallCheckLeft;
    public LayerMask wallLeft;
    public Transform wallCheckRight;
    public LayerMask wallRight;

    [Header("跳跃参数")]
    public float jumpSpeed;// 跳跃速度
    private float downTime;// 按下时间
    public float lessGravityScale;// 更小重力
    public bool isJump;// 是否跳跃
    public bool jumpPressed;// 是否按下跳跃键
    public int jumpCount;//赋予的跳跃次数
    public int jumpData;//实际的跳跃次数
    public bool canJumpTwice= false;// 是否可以二段跳
    public bool isInputSpace;// 是否按下空格
    public float wallJumpTime;// 不可左右操作时间
    public float counterForce;// 蹬墙力
    private float wallJumpCounter;// 计数器

    [Header("冲刺参数")]
    public float sprintTime;// 冲刺时间
    private float sprintTimeLeft;// 冲刺剩余时间
    private float lastSprint=-10;// 上一次冲刺时间点
    public float sprintCoolDown;// 冲刺CD
    public float sprintSpeed;// 冲刺速度
    public bool isSprint;// 是否在冲刺
    public bool canSprint=false;// 是否可以冲刺

    [Header("滑翔参数")]
    public bool isGlide=false;// 判断玩家是否在滑翔
    public bool canGlide=false;// 是否可以滑翔

    [Header("弹射参数")]
    public LayerMask bashLayer;//可以碰撞弹射的层
    public float bashRadius;//检测可弹射的范围半径
    public float bashForce;//弹射力
    public float bashSuspendTime;//遇到碰撞点时暂停时间
    public float bashTime;
    public Transform bashArrow;//弹射点指向箭头

    private Vector2 bashDirection;//角色处于可弹射时的弹射方向
    public bool canBash;//用来判断是否可以弹射
    private Collider2D[] bashPoint;//存储可弹射点的信息


    private void OnEnable() {
        EventHandle.GameFinishEvent += OnGameFinishEvent;
    }

    private void OnDisable() {
        EventHandle.GameFinishEvent -= OnGameFinishEvent;
        
    }

    private void OnGameFinishEvent()
    {
        animator.SetBool("Fall",false);
        animator.SetBool("Jump",false);
    }

    private void Start() {

        animator=GetComponent<Animator>();

        _rigidbody=GetComponent<Rigidbody2D>();

        downForce=GetComponent<ConstantForce2D>();// 获取角色身上该组件

        ctrl=GetComponentInParent<Ctrl>();

        playerData=GetComponent<PlayerData>();

        jumpCount=2;

        windArea = GameObject.FindGameObjectsWithTag("WindArea");
        
    }
    private void FixedUpdate()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position,0.1f,ground);
        isWall = Physics2D.OverlapCircle(wallCheckLeft.position,0.1f,wallLeft)
        || Physics2D.OverlapCircle(wallCheckRight.position,0.1f,wallRight);
        
        Sprinting();

        SwitchAnim();
        
        if(isSprint) return;// 若处于冲刺阶段，不调用跳跃和移动对刚体的影响

        // 爬墙
        if(wallGrab && canWall){

            if(verticalMove==0){
                animator.speed=0;
            }
            if(verticalMove!=0){
                animator.speed=1;
            }

            VerticalMove();

            gravityScale=0;

            CancelGliding();// 爬墙时终止滑翔

            foreach (var wa in windArea)
            {
                wa.GetComponent<AreaEffector2D>().enabled = false;// 关闭风区，防止player在爬墙时仍然受力向上
            }
        }else{
            gravityScale=6;

            animator.speed=1;

        }
        

        if(wallJumpCounter <= 0)
        {
            HorizontalMove();// 固定帧调用水平移动
        }
        else
        {
            wallJumpCounter-=Time.deltaTime;
        }

        Jumping();
    }
    private void Update() {
        
        JumpByDeltatime();

        wallGrab=isWall && Input.GetKey(KeyCode.J);

        if(Input.GetKeyDown(KeyCode.Space) && jumpData>0){// 跳跃
            jumpPressed=true;
        }

        // 冲刺
        if(Input.GetKeyDown(KeyCode.K)&&canSprint){
            if(Time.time>=(lastSprint+sprintCoolDown)){
                // 可以进行冲刺
                ReadyToSprint();
                ctrl.audioManager.SprintAudio();// 播放冲刺音效
            }
        
        }
        if(Input.GetKey(KeyCode.Space)) isInputSpace=true;
        else isInputSpace=false;

        
        // 滑翔
        if(Input.GetKeyDown(KeyCode.LeftShift)&&!isGlide&&canGlide&&!wallGrab){// 没有在滑翔状态时，点击shift可以进行滑翔

            GlidingState();
            ctrl.audioManager.OpenUmAudio();// 播放开伞音效

        }

        if(isGlide){

            foreach (var wa in windArea)
            {
                wa.GetComponent<AreaEffector2D>().enabled = true;// 打开风区
            }
        }

        if(Input.GetKeyUp(KeyCode.LeftShift)&&canGlide&&!wallGrab){

            CancelGliding();
            ctrl.audioManager.CloseUmAudio();// 播放关伞音效

            foreach (var wa in windArea)
            {
                wa.GetComponent<AreaEffector2D>().enabled = false;
            }
        }

        if(canSave){

            SaveGame();
        }

        if(colCount == 2){
            PlayerDie();
        }

        // if((Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.A)) && isGround){
        //     ctrl.audioManager.RunAudio();
        // }
        // if(Input.GetKeyUp(KeyCode.D) || Input.GetKeyUp(KeyCode.A) || !isGround){
        //     ctrl.audioManager.StopRunAudio();
        // }
        
    }
    void HorizontalMove(){// 水平方向移动
        
        horizontalMove=Input.GetAxisRaw("Horizontal");// 值为-1，0，1

        _rigidbody.velocity=new Vector2(horizontalMove*moveSpeed,_rigidbody.velocity.y);


        if(horizontalMove!=0){
            transform.localScale=new Vector3(horizontalMove,1,1);
            isRun=true;
        }
        if(horizontalMove==0){
            isRun=false;
        }
        
    }
    void VerticalMove(){// 竖直方向移动
        verticalMove=Input.GetAxisRaw("Vertical");
        _rigidbody.velocity=new Vector2(_rigidbody.velocity.x,verticalMove*climbSpeed);
    }

    /*void SwitchingSkill(){
        if(nowSkill>=1){
            skill[nowSkill]=false;
            nowSkill=0;
            skill[nowSkill]=true;
        }else{
            skill[nowSkill]=false;
            nowSkill++;
            skill[nowSkill]=true;
        }
    }*/

    void Jumping(){// 跳跃
        if(isGround || wallGrab){
            isJump=false;

            jumpData=jumpCount;
        }
        // if(isWall){ // 这样会碰到墙就可以一直跳，但是不这样设置，我们原来的逻辑上角色在空中只能跳一次，意味着不能连续进行蹬墙跳跃
        //             // 最好还是能设置到在墙上跳跃会有一个反向的冲力，让角色无法一直在墙上贴着跳
        //     isJump=false;

        //     jumpData=jumpCount;
        // }

        if(jumpPressed && isGround && isInputSpace && jumpData > 0){// 在地面且按下空格时跳跃
            isJump=true;
            _rigidbody.velocity=new Vector2(_rigidbody.velocity.x,jumpSpeed);
            jumpPressed=false;

            jumpData--;

            CancelGliding();// 跳跃时终止滑翔

            ctrl.audioManager.JumpAudio();// 播放跳跃音效
        }
        else if(jumpPressed  && isJump && canJumpTwice && jumpData > 0)
        {// 不在地面且处于跳跃状态按下空格时跳跃（进行二段跳）
            _rigidbody.velocity=new Vector2(_rigidbody.velocity.x,jumpSpeed);
            jumpData--;
            jumpPressed=false;

            CancelGliding();

            ctrl.audioManager.JumpAudio();// 播放跳跃音效

        }
        else if(jumpPressed  && !isJump && !isGround && !wallGrab && canJumpTwice && jumpData > 0)
        {// 不在地面且不处于跳跃状态按下空格时跳跃（不进行二段跳，只跳一次）
            _rigidbody.velocity=new Vector2(_rigidbody.velocity.x,jumpSpeed);
            jumpData=jumpData-2;
            jumpPressed=false;

            isJump = true;

            CancelGliding();

            ctrl.audioManager.JumpAudio();// 播放跳跃音效
        }
        else if(jumpPressed && wallGrab)//蹬墙跳
        {

            wallJumpCounter=wallJumpTime;
            _rigidbody.velocity=new Vector2(Input.GetAxisRaw("Horizontal") * counterForce,jumpSpeed);
            isJump=true;
            jumpData -= 2;

            canWall = false;

            StartCoroutine(JumpPressedFalse());
        }

    }
    IEnumerator JumpPressedFalse()
    {
        yield return new WaitForSeconds(0.006f);

        jumpPressed = false;
        ctrl.audioManager.JumpAudio();// 播放跳跃音效

        yield return new WaitForSeconds(0.5f);// 蹬墙跳后0.5s后才能继续爬墙，这样就可以确保在蹬墙跳的时候不会又很快黏在墙上导致出去的速度被归零
        canWall = true;

        yield return null;


    }
    
    void JumpByDeltatime(){// 跳跃高度随按下时间变化
        if(Input.GetKey(KeyCode.Space)){// 若按下空格，则按下时间逐帧增加
            downTime+=Time.deltaTime;
        }
        if(Input.GetKeyUp(KeyCode.Space)){// 在松开时将其归零并恢复原来重力
            downTime=0;
            if(isGlide==false){// 为了与滑翔状态不互相影响，让滑翔时将重力归零
                _rigidbody.gravityScale=gravityScale;
            }
        }
        if(isGlide==false){
            if(downTime>0.1){// 若按下时间大于0.05则使得重力减小
                _rigidbody.gravityScale=lessGravityScale;
            }else{
                _rigidbody.gravityScale=gravityScale;
            }
        }
    }

    void ReadyToSprint(){// 准备冲刺（放在Update里调用是为了避免帧率影响）
        isSprint=true;

        sprintTimeLeft = sprintTime;

        lastSprint = Time.time;
    }
    void Sprinting(){// 冲刺
        if(isSprint){
            if(sprintTimeLeft>0){
                
                _rigidbody.velocity = new Vector2(sprintSpeed*gameObject.transform.localScale.x ,0);

                sprintTimeLeft -= Time.deltaTime;

                ShadowPool.instance.GetFormPool();

            }
            if(sprintTimeLeft <= 0){
                isSprint = false;
                
            }
        }
    }

    void GlidingState(){
        _rigidbody.velocity=Vector2.zero;// 我们需要在滑翔的一瞬间将竖直方向的速度改为0

        _rigidbody.gravityScale=0;// 将重力设置为0
        downForce.enabled=true;// 启用恒定力（这里不直接减小重力是因为跳跃那边一直在使用，所以直接关掉用别的力好一些）

        isGlide=true;// 将角色的状态设置为正在滑翔
    }
    void CancelGliding(){
        _rigidbody.gravityScale=gravityScale;
        downForce.enabled=false;

        isGlide=false;// 若松开shift，则滑翔状态取消
    }

    void SwitchAnim(){// 切换动画
        
        if(isGround && horizontalMove != 0){
            animator.SetBool("Run",true);

        }else{
            animator.SetBool("Run",false);
        }

        if(isGround){// 如果在地上，就关闭跳跃和下坠动画
            animator.SetBool("Fall",false);
            animator.SetBool("Jump",false);
        }
        else if(!isGround&&_rigidbody.velocity.y>0){// 如果不在地上然后竖直方向速度大于0，就播放跳跃动画
            animator.SetBool("Jump",true);

        }
        else if(_rigidbody.velocity.y<0){// 如果竖直方向速度小于0，就关闭跳跃动画，播放下坠动画
            animator.SetBool("Jump",false);
            animator.SetBool("Fall",true);

            // this.GetComponent<Collider2D>().enabled = true;
        }

        if(wallGrab){
            animator.SetBool("Climb",true);
        }else{
            animator.SetBool("Climb",false);
        }
    }
    // void PlayFallAudio(){
    //     ctrl.audioManager.FallAudio();
    // }

    void Bash(){
        //发现弹射点后按下鼠标右键暂停
        if (Input.GetMouseButtonDown (1))
        {
            bashPoint = Physics2D.OverlapCircleAll (transform.position, bashRadius, bashLayer);//获得可弹射物体的碰撞点数组
            if (bashPoint.Length != 0) 
            {
                bashArrow.gameObject.SetActive (true);//显示箭头
                bashArrow.position = bashPoint [0].transform.position;//改变箭头位置为当前弹射点
                Time.timeScale = 0;//暂停
                StartCoroutine ("BushTimeWaiting");//开始计时空闲时间
                canBash = true;
            }
        } 
        //鼠标右键弹起后弹射物体
        else if (Input.GetMouseButtonUp (1) && canBash) 
        {
            bashArrow.gameObject.SetActive (false);//弹射箭头消失
            Time.timeScale = 1;//恢复正常
            bashDirection = Camera.main.ScreenToWorldPoint (Input.mousePosition) - bashPoint [0].transform.position;//得到弹射方向
            bashDirection = bashDirection.normalized;
            transform.position = new Vector3 (transform.position.x , transform.position.y , transform.position.z);//修正角色的位置
            _rigidbody.velocity = Vector2.zero;//速度归0
            //修改x,和y方向的弹力系数大小
            bashDirection.y = bashDirection.y * 1.5f;
            bashDirection.x = bashDirection.x * 0.8f;
            _rigidbody.AddForce(bashDirection*bashForce,ForceMode2D.Impulse);
            StartCoroutine ("SetBashTime");//计时弹射时间

        } 
        //未弹射时箭头跟随鼠标选择
        else if (Input.GetMouseButton (1) && canBash) 
        {
            Vector2 distance = Camera.main.ScreenToWorldPoint (Input.mousePosition) - bashPoint [0].transform.position;
            distance.Normalize ();
            float angle = Mathf.Atan2 (distance.y, distance.x) * Mathf.Rad2Deg;//得到鼠标与弹射点间的向量的角度
            bashArrow.transform.rotation = Quaternion.Euler (0,0,angle);
        }
    }

    // 使用协程处理跟弹射点暂停的时间
    private IEnumerator BushTimeWaiting()
    {
        float waitTime = Time.realtimeSinceStartup + bashSuspendTime;
        while (Time.realtimeSinceStartup < waitTime) 
        {
            yield return null;
        }
        if (Time.timeScale == 0)
        {
            Time.timeScale = 1;
            canBash = false;
            bashArrow.gameObject.SetActive (false);
        }
    }
    // 弹射过程中不能在水平方向有移动
    private IEnumerator SetBashTime()
    {
        float waitTime = Time.realtimeSinceStartup+bashTime;
        while (Time.realtimeSinceStartup < waitTime) 
        {
            yield return null;
        }
        canBash = false;
    }

    void SaveGame(){
        playerData.Save();

        ctrl.view.ShowContinueGameButton();// 只要进行了一次存档，便显示继续游戏按钮
        
    }
    void LoadGame(){
        playerData.Load();

        this.transform.parent = ctrl.transform;// 如果被下坠石块砸死，死的时候父级还是石块，会出问题，复活的时候要设置回来

    }

    void DieEffect(){
        Instantiate(die,transform.position,transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "DieTerrain"){// 碰到死亡的地形
            PlayerDie();// 调用死亡时执行的方法
        }

        if(other.tag == "Finish"){
            EventHandle.CallGameFinishEvent();
        }

    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "HitStone"){
            colCount++;
        }
    }
    private void OnCollisionExit2D(Collision2D other) {
        if(other.gameObject.tag == "HitStone"){
            colCount--;
        }
    }


    public void PlayerDie(){

        DieEffect();// 播放死亡特效

        ctrl.audioManager.DieAudio();// 播放死亡音效

        isGlide = false;// 取消滑翔，防止复活后继续

        gameObject.SetActive(false);// 让主角消失
        Invoke("LoadGame",0.5f);// 0.5s后执行LoadGame

        downTime = 0;// 死亡时让其归零，防止玩家未松开空格时死亡又在死亡时松开，导致复活后重力减小

        ctrl.initialization.RecoveryStone();// 重新实例化所有碎石
        ctrl.initialization.RecoveryTargetStone();

        EventHandle.CallPlayerDieEvent();

        canWall = true;// 加容错

        colCount = 0;

    }

    

}
