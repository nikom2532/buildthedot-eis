<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iPhone.aspx.cs" Inherits="EISClient.iPhone" %>
<!DOCTYPE html>
<html>
<head runat="server">
    <title>CGD Mobility</title>
    <meta name="apple-mobile-web-app-capable" content="yes" />
    <meta name="apple-mobile-web-app-status-bar-style" content="black" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0" />
    <link href="Styles/Site.css?v=3" rel="stylesheet" type="text/css" />
    <link href="Styles/pattern-input.css" rel="stylesheet" type="text/css" />
    <script src="Scripts/Libs/Sha1.js" type="text/javascript"></script>
    <script src="Scripts/Libs/jquery-1.9.1.min.js" type="text/javascript"></script>
    <script src="Scripts/Libs/jquery-ui-1.10.2.custom.min.js" type="text/javascript"></script>
    <script src="Scripts/Libs/jquery.ui.touch-punch.min.js" type="text/javascript"></script>
    <script src="Scripts/Libs/pattern-input.min.js" type="text/javascript"></script>
    <script src="Scripts/Service.js" type="text/javascript"></script>
    <script src="Scripts/ContentRouting.js" type="text/javascript"></script>
    <script src="Scripts/LoadingPanel.js" type="text/javascript"></script>
    <script src="Scripts/PasswordLoginPanel.js" type="text/javascript"></script>
    <script src="Scripts/PatternLoginPanel.js" type="text/javascript"></script>
    <script src="Scripts/Menu.js" type="text/javascript"></script>
    <script src="Scripts/MenuBar.js" type="text/javascript"></script>
    <script src="Scripts/ImageBox.js" type="text/javascript"></script>
    <script src="Scripts/Button.js" type="text/javascript"></script>
    <script src="Scripts/ContentPanel.js" type="text/javascript"></script>
    <script src="Scripts/PageScript.js" type="text/javascript"></script>
</head>
<body>
    <div id="container" style="height:100%; position:relative;">
        <div id="titleBar" style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; position:absolute; left:0px; top:0px; z-index:5; width:320px; height: 50px;"></div>
        <div id="footer" style="height:40px; position:absolute; bottom:0px; margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; z-index: 5;">
            <img src="Images/footer@2x.png" width="320" height="40" />
        </div>
        <div id="loadingPanel" style="display:none; top: 50px; left:0px; width:320px; height:370px; position: absolute;">
            <div class="semiTransparentBox" style="position: absolute; top: 120px; left: 85px; width: 150px; height: 100px;">
                <div id="loadingMessage" style="position:absolute; top:10px; width:100%; text-align:center; font-size: 18px;">กำลังเข้าสู่ระบบ</div>
                <img src="Images/spinner2@2x.gif" width="32" height="32" style="position: absolute; left:59px; top: 40px;" />
            </div>
        </div>
        <div id="loginPasswordPanel" style="display:none; top: 50px; left:0px; width:320px; height:370px; position: absolute;">
            <div class="semiTransparentBox" style="position: absolute; top: 120px; left: 15px; width: 290px; height: 100px;">
                <div id="loginPasswordMessage" style="position:absolute; top:20px; width:100%; text-align:center; font-size: 18px;">กรุณาใส่รหัสผ่านเพื่อเข้าระบบครั้งแรก</div>
                <div style="position:absolute; top:50px; width:100%; text-align:center;">
                    <input id="passwordInput" type="password" style="width:190px; position: absolute; top: 0px; left: 25px; height: 22px; font-size: 14px;"/>
                    <div id="okButton" class="okButton" style="width:33px; height: 31px; position: absolute; top: 0px; left: 235px;"></div>
                </div>
            </div>
        </div>
        <div id="loginPatternPanel" style="display:none;">
            <div id="patternMessageBox" class="semiTransparentBox" style="display:none; position: absolute; top: 65px; left: 32px; width: 250px; height: 30px;">
                <div id="patternMessage" style="position:absolute; top:3px; width:100%; text-align:center; font-size: 18px;">รหัสผ่านไม่ถูกต้อง กรุณาลองอีกครั้ง</div>
            </div>
            <div id="patternPanel" style="position: absolute; top: 110px; left: 32px;"></div>
            <div id="patternForget" style="display:none; position: absolute; top: 370px; left: 32px; width: 250px; height: 30px;">
                <div style="position:absolute; top:3px; width:100%; text-align:center; font-size: 18px; text-decoration: underline;">ลืมรหัสผ่าน?</div>
            </div>
        </div>
        <div id="mainPanel" style="display:none; width:320px; height:460px; overflow:hidden; ">
            <div id="menuBar" style="margin: 0px 0px 0px 0px; padding: 0px 0px 0px 0px; position:absolute; left:0px; top:8px; z-index: 4;">
                <div class="buttonBack"></div>
                <div class="buttonHome"></div>
                <div class="buttonLogout"></div>
            </div>
            <div id="menuPanel" style="position:absolute; left:0px; top:-238px; width:320; height:326px; z-index:3; display:none;" class="menuPanel">
                <div class="menuGroup">
                    <span style="padding-left:5px;">อัตรากำลัง</span>
                </div>
                <div class="menuItem" rel="numberOfEmployee">
                    อัตรากำลัง
                </div>
                <div class="menuItem" rel="estimatedRetirement">
                    ประมาณการอัตรากำลังเกษียณ
                </div>
                <div class="menuItem" rel="estimatedFundMember">
                    จำนวนสมาชิก กบข./กสจ.
                </div>
                <div style="height:10px;"></div>
                <div class="menuGroup">
                    <span style="padding-left:5px;">การเบิกจ่าย</span>
                </div>
                <div class="menuItem" rel="budgetUsage">
                    การเบิกจ่ายเงินงบประมาณภาพรวม
                </div>
                <div class="menuItem" rel="employeeRelatedBudgetUsage">
                    การเบิกจ่ายงบบุคลากร
                </div>
                <div class="menuItem" rel="retirementFundUsage">
                    บำเหน็จบำนาญ
                </div>
                <div class="menuItem" rel="warrantFundProviding">
                    บำเหน็จค้ำประกัน
                </div>
                <div class="menuItem" rel="firstCarStatus">
                    รถคันแรก
                </div>
            </div>
            <div id="contentPanel" style="position:absolute; left:320px; top:90px; width:320px; height: 370px; z-index:2;">
                <div id="titleLabel" style="position:absolute; left:0px; top:0px; width:297px; height:31px; z-index:2;" class="titleLabel">อัตรากำลัง</div>
                <div style="position:absolute; top:31px; width:320px">
                    <div id="yearLabel" style="position:absolute; right:0px; top:9px; width:130px; height: 20px; z-index:2;" class="yearLabel">ปีงบประมาณ <span id="yearText"></span></div>
                    <div id="imageBox" style="position:absolute; top:0px; left:0px; width: 320px; height: 290px; z-index:1; background-color:White;"></div>
                    <div id="imageBox2" style="position:absolute; top:0px; left:0px;  width: 320px; height: 290px; z-index:1; background-color:White;"></div>                
                </div>
            </div>
            <div id="bottomBar" style="position:absolute; left:0; top:460px; width:320px; height:50px; z-index:5; margin-left: auto; margin-right: auto; display: table-cell; text-align: center;">
                <div id="bottomBarInner" style="width:100%; height:100%;"></div>
            </div>
        </div>

    </div>
</body>
</html>