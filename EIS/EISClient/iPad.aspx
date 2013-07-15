
<!DOCTYPE html>
<html>
<head id="Head1" runat="server">
    <title>CGD Mobility</title>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <link href="Styles/Site2.css?v=3" rel="stylesheet" type="text/css" />
    <link href="Styles/pattern-input-ipad.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/iPad/Libs/Sha1.js" type="text/javascript"></script>
    <script src="Scripts/iPad/Libs/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="Scripts/iPad/Libs/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/iPad/Libs/jquery.ui.touch-punch.min.js" type="text/javascript"></script>
    <script src="Scripts/iPad/Libs/pattern-input.min.js" type="text/javascript"></script>
    <script src="Scripts/iPad/Service.js" type="text/javascript"></script>
    <script src="Scripts/iPad/ContentRouting.js" type="text/javascript"></script>
    <script src="Scripts/iPad/LoadingPanel.js" type="text/javascript"></script>
    <script src="Scripts/iPad/PasswordLoginPanel.js" type="text/javascript"></script>
    <script src="Scripts/iPad/PatternLoginPanel.js" type="text/javascript"></script>
    <script src="Scripts/iPad/Menu.js" type="text/javascript"></script>
    <script src="Scripts/iPad/MenuBar.js" type="text/javascript"></script>
    <script src="Scripts/iPad/ImageBox.js" type="text/javascript"></script>
    <script src="Scripts/iPad/Button.js" type="text/javascript"></script>
    <script src="Scripts/iPad/ContentPanel.js" type="text/javascript"></script>
    <script src="Scripts/iPad/PageScript.js" type="text/javascript"></script>
</head>
<body>
    <div id="container" style="height:100%; position:relative;">
     <div id="titleBar" style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; position:absolute; left:0px; top:0px; z-index:5; width:1024px; height:  138px;"></div>
        <div id="footer" style="height:51px; position:fixed; bottom:0px; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; z-index: 5;">
            <img src="Images/iPad/footer.png" width="1024" height="51" />
        </div>
        <div id="loadingPanel" style="display:none; top: 50px; left:0px; width:320px; height:370px; position: absolute;">
            <div class="semiTransparentBox" style="position: absolute; top: 120px; left: 85px; width: 150px; height: 100px;">
                <div id="loadingMessage" style="position:absolute; top:10px; width:100%; text-align:center; font-size: 18px;">กำลังเข้าสู่ระบบ</div>
                <img src="Images/spinner2@2x.gif" width="32" height="32" style="position: absolute; left:59px; top: 40px;" />
            </div>
        </div>
        <div id="loginPasswordPanel" style="display:none; top: 50px; left:0px; width:320px; height:370px; position: absolute;">
            <div class="semiTransparentBox" style="position: absolute; top: 240px; left: 227px; width: 573px; height: 210px;">
                <div id="loginPasswordMessage" style="position:absolute; top:40px; width:100%; text-align:center; font-size: 27.5px;">กรุณาใส่รหัสผ่านเพื่อเข้าระบบครั้งแรก</div>
                <div style="position:absolute; top:50px; width:100%; text-align:center;">
                    <input id="passwordInput" type="password" style="width:355px; position: absolute; top: 45px; left: 57px; height: 45px; font-size: 27.5px;"/>
                    <div id="okButton" class="okButton" style="width:64px; height: 70px; position: absolute; top: 40px; left: 465px;"></div>
                </div>
            </div>
        </div>
        <div id="loginPatternPanel" style="display:none;">
            <div id="patternMessageBox" class="semiTransparentBox" style="display:none; position: absolute; top: 65px; left: 32px; width: 250px; height: 30px;">
                <div id="patternMessage" style="position:absolute; top:3px; width:100%; text-align:center; font-size: 18px;">รหัสผ่านไม่ถูกต้อง กรุณาลองอีกครั้ง</div>
            </div>
            <div id="patternPanel" style="position: absolute; top: 170px; left: 285px;"></div>
            <div id="patternForget" style="display:none; position: absolute; top: 645px; left: 355px; width: 250px; height: 30px;">
                <div style="position:absolute; top:3px; width:100%; text-align:center; font-size: 18px; text-decoration: underline;">ลืมรหัสผ่าน?</div>
            </div>
        </div>
        <div id="mainPanel" style="display:none; width:880px; height:320px; overflow:hidden; ">
            <div id="menuBar" style="margin: -20px 0px 0px 0px; padding: 0px 0px 0px 0px; position:absolute; left:547px; top:0px; z-index: 6;">
                <div class="buttonBack"></div>
                <div class="buttonHome"></div>
                <div class="buttonLogout"></div>
            </div>
            <div id="menuPanel" style="position:absolute; left:0px; top:90px; width:880px; height:500px; z-index:3; display:none;" class="menuPanel">
                <div id="menuTab" style="position:absolute;left:880px; top:130px;"></div>
                <div class="menuGroup">
                    <span style="padding-left:39px;">อัตรากำลัง</span>
                </div>
                <div class="menuItem" rel="numberOfEmployee" style="margin-top:8px; margin-left:25px;">
                    อัตรากำลัง
                </div>
                <div class="menuItem" rel="estimatedRetirement" style="margin-left:25px;">
                    ประมาณการอัตรากำลังเกษียณ
                </div>
                <div class="menuItem" rel="estimatedFundMember" style="margin-left:25px; border-bottom: 0px solid white;">
                    จำนวนสมาชิก กบข./กสจ.
                </div>
                <div style="height:10px;"></div>
                <div class="menuGroup" >
                    <span style="padding-left:39px;">การเบิกจ่าย</span>
                </div>
                <div class="menuItem" rel="budgetUsage" style="margin-top:8px; margin-left:25px;">
                    การเบิกจ่ายเงินงบประมาณภาพรวม
                </div>
                <div class="menuItem" rel="employeeRelatedBudgetUsage" style="margin-left:25px;">
                    การเบิกจ่ายงบบุคลากร
                </div>
                <div class="menuItem" rel="retirementFundUsage" style="margin-left:25px;">
                    บำเหน็จบำนาญ
                </div>
                <div class="menuItem" rel="warrantFundProviding" style="margin-left:25px;">
                    บำเหน็จค้ำประกัน
                </div>
                <div class="menuItem" rel="firstCarStatus" style="margin-left:25px;border-bottom: 0px solid white;">
                    รถคันแรก
                </div>
              
            </div>
            <div id="contentPanel" style="position:absolute; left:1024px; top:173px; width:928px; height: 768px; z-index:2;">
                <div id="titleLabel" style="position:absolute; left:0px; top:0px; width:883px; height:40px; z-index:2;" class="titleLabel">อัตรากำลัง</div>
                <div style="position:absolute; top:40px; width:928px">
                    <div id="yearLabel" style="position:absolute; right:0px; top:20px; width:225px; height: 30px; z-index:2;" class="yearLabel">ปีงบประมาณ <span id="yearText"></span></div>
                    <div id="imageBox" style="position:absolute; top:0px; left:0px; width: 680px; height: 768px; z-index:1; background-color:White;"></div>
                    <div id="imageBox2" style="position:absolute; top:0px; left:0px;  width: 680px; height: 768px; z-index:1; background-color:White;"></div>                
                </div>
            </div>
        
            <div id="bottomBar" style="position:absolute; left:0; top:670px; width:1024px; height:50px; z-index:5; margin-left: auto; margin-right: auto; display: table-cell; text-align: center;">
                <div id="bottomBarInner" style="position:absolute; left:0; top:670px; width:1024px; height:50px; z-index:5; margin-left: auto; margin-right: auto; display: block; text-align: center;" style="width:100%; height:100%;"></div>
            </div>
     
        </div>

    </div>
</body>
</html>