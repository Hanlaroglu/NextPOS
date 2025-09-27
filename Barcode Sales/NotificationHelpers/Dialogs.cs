using DevExpress.Utils.Html;
using DevExpress.XtraEditors;

namespace Barcode_Sales.NotificationHelpers
{
    public static class Dialogs
    {
        private static readonly string css = @"
body{
	padding: 15px;
	font-size: 12pt;
	font-family: 'Nunito';
	text-align: center;
}
.frame{
	color: @ControlText;
	background-color: @White;
	border: 1px solid @Black/0.2;
	border-radius: 10px;
	box-shadow: 0px 5px 10px 0px rgba(0, 0, 0, 0.2);
}
.content {
	padding: 15px;
}
.text {
	padding: 10px;
	text-align: left;
}
.caption {
	font-size: 15pt;
	font-family: 'Nunito';
}
.message {
	white-space: pre;
}
.buttons {
	background-color: @Control;
	padding: 20px;
	display: flex;
	flex-direction: row;
	justify-content: center;
	border-top: 1px solid @Black/0.1;
	border-radius: 0px 0px 10px 10px;
}
.button {
	color: @WindowText;
	background-color: @White;
	min-width: 80px;
	margin: 0px 5px;
	padding: 5px;
    border: 1px solid @Black/0.15;
    border-radius: 5px;
}
.button:hover {
	background-color: @Black/0.1;
}
.button:focus {
	background-color: @HighlightAlternate;
	border: 1px solid @HighlightAlternate;
	color: @White;
}";

        public static XtraMessageBoxArgs DialogResultYesNo(string message, string caption = "Bildiriş")
        {
            HtmlTemplateCollection templates = new HtmlTemplateCollection();

            string html = @"<div class=""frame"" id=""frame"">
	<div class=""content"">
	    <div class=""text caption"">${Caption}</div>
		<div id=""content"">
		   	<div class=""text message"">${MessageText}</div>
		</div>
	</div>
	<div class=""buttons"">
		<div class=""button"" tabindex=""1"" id=""dialogresult-yes"">Bəli</div>
    	<div class=""button"" tabindex=""2"" id=""dialogresult-no"">Xeyr</div>
    </div>
</div>";


            HtmlTemplate template = new HtmlTemplate
            {
                Template = html,
                Styles = css
            };


            templates.Add(template);


            XtraMessageBoxArgs args = GetMessageArgs();
            args.HtmlTemplate.Assign(templates[0]);
            args.Caption = caption;
            args.Text = message;
            args.DefaultButtonIndex = 0;
            return args;
        }

        public static XtraMessageBoxArgs GetMessageArgs()
        {
            XtraMessageBoxArgs args = new XtraMessageBoxArgs();
            args.Caption = "Xəbərdarlıq";
            args.Text = "Verilənlər bazasının ehtiyat nüsxəsi saxlanılsınmı ?";
            //args.ImageOptions.SvgImage = SvgImage;
            return args;
        }
    }
}
