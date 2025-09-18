using DevExpress.Utils;
using DevExpress.XtraBars.Alerter;
using DevExpress.XtraEditors;

namespace Barcode_Sales.NoticationHelpers
{
    public class Messages
    {
		private static readonly string html = @"<div class=""container"">
    <div class=""popup"">        	
    	<div class=""stripe""></div>
    	<div class=""content"">
    		<div class=""icon-container"">
        		<img class=""icon"" src='${SvgImage}'>
    		</div>
        	<div class=""message"">
            	<div class=""caption"">${Caption}</div>
            	<div class=""text"">${Text}</div>
        	</div>
    	</div>
    </div>
</div>";

        public static SvgImageCollection svgImages { get; } = new SvgImageCollection
        {
            { "success", Properties.Resources.check_circle_fill },
            { "warning",  Properties.Resources.warning_fill },
            { "error",  Properties.Resources.x_circle_fill },
            { "info",  Properties.Resources.info_fill },
        };

        public static void SuccessMessage(XtraForm form, string message, string caption = "Mesaj")
        {
            string css = @"
.container{
	width: 378px;
	height: auto;
	padding: 7px 12px 12px 7px;
}
.popup{
	background-color: @Window/0.95;
	border-radius: 6px;
	border-style: solid;
	border-width: 1px 1px 1px 0px;
	box-shadow: 2px 2px 12px @Black/0.2;
	border-color: @Success/0.3;
	display: flex;
	flex-direction: row;
}
.content{
	width: 100%;
	display: flex;
	flex-direction: row;
	align-items: center;
	background-color: @Black/0.015
}
.stripe{
	width: 3px;
	background-color: @Success/0.8;
	height: 100%;
	border-radius: 6px 0px 0px 6px;
}
.message{
	display: flex;
	flex-direction: column;
	padding: 8px;
	font-family: 'Nunito';
	color: @WindowText;
}
.icon-container{
	padding: 8px;
}
.icon{
	width: 22px;
	height: 22px;
}
.caption{
	font-size: 11pt;
	font-weight: bold;
	padding: 6px;
}
.text{
	font-size: 10.5pt;
	padding: 0px 6px 6px 6px;
}
.close-button{
	padding: 8px;
	border-radius: 4px 0px 0px 4px;
}
.close-button:hover{
	background-color: @Black/0.1;
}
.close-button:active{
	background-color: @Black/0.2;
}
.close-icon{
	width: 22px;
	height: 22px;
}";

            AlertControl alertControl = new AlertControl();
            alertControl.HtmlTemplate.Styles = css;
            alertControl.HtmlTemplate.Template = html;
			

            AlertInfo alertInfo = new AlertInfo(caption, message);
            alertControl.FormLocation = AlertFormLocation.TopRight;
            alertControl.ShowAnimationType = AlertFormShowingEffect.MoveHorizontal;
            alertControl.FormDisplaySpeed = AlertFormDisplaySpeed.Fast;

            alertInfo.SvgImage = svgImages["success"];
            alertControl.Show(form, alertInfo);
        }

        public static void WarningMessage(XtraForm form, string message, string caption = "Bildiriş")
        {
            string css = @"
.container{
	width: 378px;
	height: auto;
	padding: 7px 12px 12px 7px;
}
.popup{
	background-color: @Window/0.95;
	border-radius: 6px;
	border-style: solid;
	border-width: 1px 1px 1px 0px;
	box-shadow: 2px 2px 12px @Black/0.2;
	border-color: @Warning/0.3;
	display: flex;
	flex-direction: row;
}
.content{
	width: 100%;
	display: flex;
	flex-direction: row;
	align-items: center;
	background-color: @Black/0.015
}
.stripe{
	width: 3px;
	background-color: @Warning/0.8;
	height: 100%;
	border-radius: 6px 0px 0px 6px;
}
.message{
	display: flex;
	flex-direction: column;
	padding: 8px;
	font-family: 'Nunito';
	color: @WindowText;
}
.icon-container{
	padding: 8px;
}
.icon{
	width: 22px;
	height: 22px;
}
.caption{
	font-size: 12pt;
	font-weight: bold;
	padding: 6px;
}
.text{
	font-size: 11pt;
	padding: 0px 6px 6px 6px;
}
.close-button{
	padding: 8px;
	border-radius: 4px 0px 0px 4px;
}
.close-button:hover{
	background-color: @Black/0.1;
}
.close-button:active{
	background-color: @Black/0.2;
}
.close-icon{
	width: 22px;
	height: 22px;
}";

            AlertControl alertControl = new AlertControl();
            alertControl.HtmlTemplate.Styles = css;
            alertControl.HtmlTemplate.Template = html;

            AlertInfo alertInfo = new AlertInfo(caption, message);
            alertControl.FormLocation = AlertFormLocation.TopRight;
            alertControl.ShowAnimationType = AlertFormShowingEffect.MoveHorizontal;
            alertControl.FormDisplaySpeed = AlertFormDisplaySpeed.Fast;


            alertInfo.SvgImage = svgImages["warning"];
            alertControl.Show(form, alertInfo);
        }

        public static void ErrorMessage(XtraForm form, string message, string caption = "Xəta")
        {
            string css = @"
.container{
	width: 378px;
	height: auto;
	padding: 7px 12px 12px 7px;
}
.popup{
	background-color: @Window/0.95;
	border-radius: 6px;
	border-style: solid;
	border-width: 1px 1px 1px 0px;
	box-shadow: 2px 2px 12px @Black/0.2;
	border-color: @Danger/0.3;
	display: flex;
	flex-direction: row;
}
.content{
	width: 100%;
	display: flex;
	flex-direction: row;
	align-items: center;
	background-color: @Black/0.015
}
.stripe{
	width: 3px;
	background-color: @Danger/0.8;
	height: 100%;
	border-radius: 6px 0px 0px 6px;
}
.message{
	display: flex;
	flex-direction: column;
	padding: 8px;
	font-family: 'Nunito';
	color: @WindowText;
}
.icon-container{
	padding: 8px;
}
.icon{
	width: 22px;
	height: 22px;
}
.caption{
	font-size: 12pt;
	font-weight: bold;
	padding: 6px;
}
.text{
	font-size: 11pt;
	padding: 0px 6px 6px 6px;
}
.close-button{
	padding: 8px;
	border-radius: 4px 0px 0px 4px;
}
.close-button:hover{
	background-color: @Black/0.1;
}
.close-button:active{
	background-color: @Black/0.2;
}
.close-icon{
	width: 22px;
	height: 22px;
}";

            AlertControl alertControl = new AlertControl();
            alertControl.HtmlTemplate.Styles = css;
            alertControl.HtmlTemplate.Template = html;
            alertControl.FormLocation = AlertFormLocation.TopRight;
            alertControl.ShowAnimationType = AlertFormShowingEffect.MoveHorizontal;
            alertControl.FormDisplaySpeed = AlertFormDisplaySpeed.Fast;

            AlertInfo alertInfo = new AlertInfo(caption, message);
            alertInfo.SvgImage = svgImages["error"];

            alertControl.Show(form, alertInfo);
        }

        public static void InfoMessage(XtraForm form, string message, string caption = "Mesaj")
        {
            string css = @"
.container{
	width: 378px;
	height: auto;
	padding: 7px 12px 12px 7px;
}
.popup{
	background-color: @Window/0.95;
	border-radius: 6px;
	border-style: solid;
	border-width: 1px 1px 1px 0px;
	box-shadow: 2px 2px 12px @Black/0.2;
	border-color: @Primary/0.3;
	display: flex;
	flex-direction: row;
}
.content{
	width: 100%;
	display: flex;
	flex-direction: row;
	align-items: center;
	background-color: @Black/0.015
}
.stripe{
	width: 3px;
	background-color: @Primary/0.8;
	height: 100%;
	border-radius: 6px 0px 0px 6px;
}
.message{
	display: flex;
	flex-direction: column;
	padding: 8px;
	font-family: 'Nunito';
	color: @WindowText;
}
.icon-container{
	padding: 8px;
}
.icon{
	width: 22px;
	height: 22px;
}
.caption{
	font-size: 12pt;
	font-weight: bold;
	padding: 6px;
}
.text{
	font-size: 11pt;
	padding: 0px 6px 6px 6px;
}
.close-button{
	padding: 8px;
	border-radius: 4px 0px 0px 4px;
}
.close-button:hover{
	background-color: @Black/0.1;
}
.close-button:active{
	background-color: @Black/0.2;
}
.close-icon{
	width: 22px;
	height: 22px;
}";

            AlertControl alertControl = new AlertControl();
            alertControl.HtmlTemplate.Styles = css;
            alertControl.HtmlTemplate.Template = html;

            AlertInfo alertInfo = new AlertInfo(caption, message);
            alertControl.FormLocation = AlertFormLocation.TopRight;
            alertControl.ShowAnimationType = AlertFormShowingEffect.MoveHorizontal;
            alertControl.FormDisplaySpeed = AlertFormDisplaySpeed.Fast;


            alertInfo.SvgImage = svgImages["info"];
            alertControl.Show(form, alertInfo);
        }
    }
}