﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProjectItemListTreeMap.ascx.cs" Inherits="WebProjectManagement.Forms.ProjectItemListTreeMap" %>

<%@ Register TagPrefix="telerik" Namespace="Telerik.Web.UI" Assembly="Telerik.Web.UI" %>
<div>
    <style>
        #example .demo-container {
            max-width: 1270px;
            padding-top: 40px;
            background: url(images/header.jpg) no-repeat top left;
            overflow: hidden;
        }

        .boldText {
            font-weight: bold;
            cursor: pointer;
        }

        html .RadToolTip .rtContent {
            padding: 7px 20px 20px 80px;
        }

        .RadToolTip .rtContent span {
            display: block;
        }

        .RadToolTip .rank {
            width: 66px;
            height: 50px;
            position: absolute;
            top: 2px;
            left: 2px;
            padding-top: 10px;
            color: #fff;
            background-color: #777;
            text-align: center;
        }

            .RadToolTip .rank:before {
                width: 0;
                content: "";
                position: absolute;
                left: 0;
                bottom: -20px;
                border-width: 10px 33px;
                border-style: solid;
                border-color: #777 transparent transparent;
            }

        .RadToolTip .rankText {
            font-size: 14px;
        }

        .RadToolTip .rankValue {
            font-size: 20px;
        }

        .RadToolTip .content {
            background-repeat: no-repeat;
            background-position: 85px 45px;
        }

        .RadToolTip .Basketball {
            background-image: url("images/basketball.png");
        }

        .RadToolTip .Tennis {
            background-image: url("images/tenis.png");
        }

        .RadToolTip .Boxing {
            background-image: url("images/boxing.png");
        }

        .RadToolTip .Football {
            background-image: url("images/football.png");
        }

        .RadToolTip .Golf {
            background-image: url("images/golf.png");
        }

        .RadToolTip .Racing {
            background-image: url("images/racing.png");
        }

        .RadToolTip .Soccer {
            background-image: url("images/soccer.png");
        }

        .RadToolTip .header {
            font-size: 20px;
        }

        .RadToolTip .sport {
            display: block;
            margin: 10px 0;
        }


        .RadToolTip ul {
            list-style-type: none;
            margin: 0;
            padding: 0;
        }

        .RadToolTip li {
            border-bottom: 1px solid #eee;
            position: relative;
        }

        .RadToolTip .list {
            text-transform: capitalize;
            text-align: left;
        }

            .RadToolTip .list span {
                line-height: 24px;
            }

        .RadToolTip .listValue {
            position: absolute;
            right: 0;
            top: 0;
        }

        .RadToolTip_Black .rank {
            background-color: #000;
        }

            .RadToolTip_Black .rank:before {
                border-top-color: #000;
            }

        .RadToolTip_Black li {
            border-color: #ababab;
        }

        .RadToolTip_BlackMetroTouch .rank {
            background-color: #25a0da;
        }

            .RadToolTip_BlackMetroTouch .rank:before {
                border-top-color: #25a0da;
            }

        .RadToolTip_BlackMetroTouch li {
            border-color: #3b3b3b;
        }

        .RadToolTip_Default .rank {
            background-color: #828282;
        }

            .RadToolTip_Default .rank:before {
                border-top-color: #828282;
            }

        .RadToolTip_Glow .rank {
            background-color: #f89d26;
        }

            .RadToolTip_Glow .rank:before {
                border-top-color: #f89d26;
            }

        .RadToolTip_Metro .rank {
            color: #25a0da;
            background-color: #ffffff;
        }

            .RadToolTip_Metro .rank:before {
                border-top-color: #ffffff;
            }

        .RadToolTip_MetroTouch .rank {
            background-color: #25a0da;
        }

            .RadToolTip_MetroTouch .rank:before {
                border-top-color: #25a0da;
            }

        .RadToolTip_Office2007 .rank {
            background-color: #6187b8;
        }

            .RadToolTip_Office2007 .rank:before {
                border-top-color: #6187b8;
            }

        html .RadToolTip_Office2007 .rtContent {
            background-color: #d7e3f2;
        }

        .RadToolTip_Office2007 li {
            border-color: #acb6c2;
        }

        .RadToolTip_Office2010Black .rank {
            background-color: #262626;
        }

            .RadToolTip_Office2010Black .rank:before {
                border-top-color: #262626;
            }

        .RadToolTip_Office2010Black li {
            border-color: #6f6f6f;
        }

        .RadToolTip_Office2010Blue .rank {
            background-color: #8ba0bc;
        }

            .RadToolTip_Office2010Blue .rank:before {
                border-top-color: #8ba0bc;
            }

        .RadToolTip_Office2010Silver .rank {
            background-color: #9aa0a6;
        }

            .RadToolTip_Office2010Silver .rank:before {
                border-top-color: #9aa0a6;
            }

        html .RadToolTip_Office2010Silver .rtContent {
            background-color: #f1f3f5;
        }

        .RadToolTip_Office2010Silver li {
            border-color: #cdced0;
        }

        .RadToolTip_Outlook .rank {
            background-color: #6187b8;
        }

            .RadToolTip_Outlook .rank:before {
                border-top-color: #6187b8;
            }

        .RadToolTip_Silk .rank {
            background-color: #2dabc1;
        }

            .RadToolTip_Silk .rank:before {
                border-top-color: #2dabc1;
            }

        .RadToolTip_Simple .rank {
            background-color: #ffa517;
        }

            .RadToolTip_Simple .rank:before {
                border-top-color: #ffa517;
            }

        .RadToolTip_Simple li {
            border-color: #d6cd91;
        }

        .RadToolTip_Sunset .rank {
            background-color: #bb903e;
        }

            .RadToolTip_Sunset .rank:before {
                border-top-color: #bb903e;
            }

        .RadToolTip_Sunset li {
            border-color: #d6cd91;
        }

        .RadToolTip_Telerik .rank {
            background-color: #6b6b6b;
        }

            .RadToolTip_Telerik .rank:before {
                border-top-color: #6b6b6b;
            }

        .RadToolTip_Vista .rank {
            background-color: #767676;
        }

            .RadToolTip_Vista .rank:before {
                border-top-color: #767676;
            }

        .RadToolTip_Vista li {
            border-color: #cccdd5;
        }

        .RadToolTip_Web20 .rank {
            background-color: #597cb3;
        }

            .RadToolTip_Web20 .rank:before {
                border-top-color: #597cb3;
            }

        .RadToolTip_Web20 li {
            border-color: #c5ccd6;
        }

        .RadToolTip_WebBlue .rank {
            background-color: #768ca5;
        }

            .RadToolTip_WebBlue .rank:before {
                border-top-color: #768ca5;
            }

        .RadToolTip_WebBlue li {
            border-color: #b7b7c0;
        }

        .RadToolTip_Windows7 .rank {
            background-color: #a0afc3;
        }

            .RadToolTip_Windows7 .rank:before {
                border-top-color: #a0afc3;
            }

        .RadToolTip_Windows7 li {
            border-color: #ced6e1;
        }
    </style>


    <script type="text/javascript">
        (function () {

            var $;
            var tooltipManager;
            var demo = window.demo = window.demo || {};

            demo.initialize = function () {
                tooltipManager = window.tooltipManager;
            };
            window.onClientItemCreated = function (sender, args) {
                //  var toolTipValue = args.get_dataItem().value;
                var itemElement = args.get_element();
                var itemCode = itemElement.getElementsByClassName('itemCode')[0].innerHTML;
                $telerik.$(itemElement).on("click", function (e) {//"mouseover", function (e) {
                    showTooltip(itemCode, itemElement);
                    e.stopPropagation();
                });
            }

            function showTooltip(toolTipValue, itemElement) {
                if ($telerik.$(itemElement).hasClass("k-leaf") || true) {
                    var mainElement = itemElement;


                    var tooltip = tooltipManager.getToolTipByElement(mainElement);

                    if (!tooltip) {
                        tooltip = tooltipManager.createToolTip(mainElement);
                    }

                    if (toolTipValue != tooltip.get_value() || !tooltip.isVisible()) {
                        tooltip.set_value(toolTipValue);

                        setTimeout(function () {
                            tooltip.show();
                        }, 10);
                    }
                }
            }
        })();
    </script>


    <div style="width: 100%">
        <telerik:RadToolBar runat="server" ID="tbrActions" OnButtonClick="tbrActions_ButtonClick" Width="100%">
            <Items>
                <telerik:RadToolBarButton ImageUrl="~/Images/Controls/toolbar_add.png" Text="افزودن آیتم اصلی" Value="AddMainNode"></telerik:RadToolBarButton>
            </Items>
        </telerik:RadToolBar>
    </div>
    <div class="demo-container no-bg">
        <telerik:RadToolTipManager RenderMode="Lightweight" runat="server" ID="TTM1" ShowEvent="FromCode" EnableShadow="false" Width="350px" HideEvent="LeaveTargetAndToolTip"
            RelativeTo="Element" Position="TopCenter" EnableRoundedCorners="false" ShowCallout="true" Style="z-index: 100000">
            <WebServiceSettings Path="Services/ProjectManagementService.asmx" Method="ToolTipInfo"></WebServiceSettings>
        </telerik:RadToolTipManager>
        <br />
        <telerik:RadTreeMap RenderMode="Lightweight" runat="server" ID="TreeMap1" OnClientItemCreated="onClientItemCreated"
            DataKeyNames="Name,ItemDescription,id" AlgorithmType="Vertical" Skin="Metro" >
            <ClientItemTemplate>                
                 <div class="boldText" style="display:inline;">#=dataItem.Name # - #=text #%</div>
                <div>#=dataItem.ItemDescription #</div>
                <div class="itemCode" style="visibility:hidden;">#=dataItem.id #</div>
                <%--<div> <img class="btnEnterData" title="" alt="ورود اطلاعات"  src="/Images/Controls/read.png" width="64px" heigh="64px" onClick="selectedItem('btnEnterData', #=dataItem.id #);"/></div>--%>
            </ClientItemTemplate>
        </telerik:RadTreeMap>

    </div>
    <input type="hidden" name="HiddenField" id="selectedItemCode" enableviewstate="true" />
    <script type="text/javascript">
        Sys.Application.add_load(function () {
            window.tooltipManager = $find("<%=TTM1.ClientID%>");
            demo.initialize();
        });

        function selectedItem(value, code) {
            var h = document.getElementById('selectedItemCode');
            h.value = value + "-" + code.toString();
            console.log(h.value.toString());
            __doPostBack('selectedItemCode', '');
            //    location.reload();
        }

    </script>

</div>
