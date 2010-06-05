<%@ Page Language="C#" CodeBehind="Default.aspx.cs" Inherits="NDueTime.Demo._Default" %>
<%@ Import Namespace="NDueTime" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>NDueTime Demo</title>
	<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
	<meta name="author" content="Kevin Gorski">
	<meta name="keywords" content="date, time, .NET, fluent interface, parsing">
	<link rel="Stylesheet" type="text/css" href="Styles/style.css" />
	<link rel="stylesheet" type="text/css" href="http://fonts.googleapis.com/css?family=OFL+Sorts+Mill+Goudy+TT" />
	<script type="text/javascript" src="http://www.google.com/jsapi?key=ABQIAAAA1XbMiDxx_BTCY2_FkPh06RRaGTYH6UMl8mADNa0YKuWNNa8VNxQEerTAUcfkyrr6OwBovxn7TDAH5Q"></script>
</head>
<body>
	<h1>NDueTime</h1>
	<h2>Lightweight date & time library for .NET</h2>
	
	<dl>
		<dt>Latest Release</dt>
		<dd><a href="http://github.com/downloads/kevingorski/NDueTime/NDueTime-<%= LibraryVersionNumber %>.zip">Version <%= LibraryVersionNumber %></a></dd>
	</dl>
	<dl>	
		<dt>Source on GitHub</dt>
		<dd><a href="http://github.com/kevingorski/NDueTime">NDueTime</a></dd>
	</dl>
	<dl>	
		<dt>Author</dt>
		<dd><a href="http://kevingorski.com">Kevin Gorski</a></dd>
	</dl>
	
	<div class="Clear"></div>
	
	<p>
		NDueTime is a collection of date & time utilities and extension methods to provide:
	</p>
	
	<ul>
		<li>Easier to read <span class="Class">DateTime</span> and <span class="Class">TimeSpan</span> functionality</li>
		<li>Easy to use English language relative time parsing and serialization</li>
	</ul>
	
	<p>
		The scope of this project is intentionally small, but feel free to <a href="http://github.com/kevingorski/NDueTime/issues">create a feature request</a> or <a href="http://help.github.com/forking/">fork the project</a>, add a feature, and submit a pull request.
	</p>
	
	<h2>Demos</h2>
	<p>All times are local to the server.</p>
	<ul id="DemoList">
		<li>English language parsing and display
			<ul>
				<li><a href="#ParsingRelativeTimes">Parsing relative time expressions</a></li>
				<li><a href="#RelativeTimeExpressions">Creating Relative Time expressions from <span class="Class">DateTime</span>s</a></li>
			</ul>
		</li>
		<li>Clearer API for working with time
			<ul>
				<li><a href="#RelativeDateTimeCreation">Relative <span class="Class">DateTime</span> creation</a></li>
				<li><a href="#FormattingTimeSpans">Formatting <span class="Class">TimeSpans</span></a></li>
			</ul>
		</li>
	</ul>
	
    <form id="form1" runat="server">
		<asp:ScriptManager runat="server" />
		
		<a id="ParsingRelativeTimes"></a>
		<div class="FeatureSection">
			<h3>Parsing relative time expressions</h3>
			<p>This performs a simplified version of the Google Calendar parsing algorithm. Some things to try:</p>
			<ul id="RelativetimeExamples">
				<li>10 AM</li>
				<li>Half past noon</li>
				<li>Next Tuesday at 3 PM</li>
				<li>Quarter until 5 PM last Friday</li>
			</ul>
			<asp:UpdatePanel ID="RelativeTimeContainer" runat="server">
				<ContentTemplate>
					<asp:TextBox ID="RelativeTimeExpression" runat="server" /><asp:Button ID="Parse" runat="server" Text="Parse" /><img src="Images/progress.gif" alt="Waiting for server response" class="ProgressIndicator" >
					<div><asp:RequiredFieldValidator runat="server" 
						ControlToValidate="RelativeTimeExpression" 
						ErrorMessage="Don't know what to try? Click one of the examples." /></div>
					
					<pre class="Source"><%= RelativeTimeExpression.Text %>&nbsp;</pre>
					<pre class="Result"><asp:Literal ID="ParsedDateTime" runat="server" />&nbsp;</pre>
				</ContentTemplate>
			</asp:UpdatePanel>
		</div>
		
		<a id="RelativeTimeExpressions"></a>
		<div class="FeatureSection">
			<h3>Creating Relative Time expressions from <span class="Class">DateTime</span>s</h3>
			
			<p>The source <span class="Class">DateTime</span> would normally be contextual or provided by an entity, but this should give you an idea of what to expect:</p>
			<pre class="Source">DateTime.Now.ToRelativeTimeString()</pre>
			<pre class="Result"><%= DateTime.Now.ToRelativeTimeString() %></pre>
			
			<pre class="Source">5.Minutes().Ago().ToRelativeTimeString()</pre>
			<pre class="Result"><%= 5.Minutes().Ago().ToRelativeTimeString() %></pre>
			
			<pre class="Source">2.Hours().FromNow().ToRelativeTimeString()</pre>
			<pre class="Result"><%= 2.Hours().FromNow().ToRelativeTimeString() %></pre>
			
			<p>3.Days().Ago() works as well, but any <span class="Class">TimeSpan</span> will work.</p>
			<pre class="Source">TimeSpan.FromDays(3).Ago().ToRelativeTimeString()</pre>
			<pre class="Result"><%= TimeSpan.FromDays(3).Ago().ToRelativeTimeString() %></pre>
		</div>
		
		<a id="RelativeDateTimeCreation"></a>
		<div class="FeatureSection">
			<h3>Relative <span class="Class">DateTime</span> creation</h3>
			
			<p>The famous Rails example:</p>
			<pre class="Source">5.Minutes().Ago().ToShortTimeString()</pre>
			<pre class="Result"><%= 5.Minutes().Ago().ToShortTimeString() %></pre>
			
			<p>The relative part works on any <span class="Class">TimeSpan</span>:</p>
			<pre class="Source">TimeSpan.FromHours(2).Ago().ToShortTimeString()</pre>
			<pre class="Result"><%= TimeSpan.FromHours(2).Ago().ToShortTimeString()%></pre>
			
			<p>"From now" for future times:</p>
			<pre class="Source">15.Minutes().FromNow().ToShortTimeString()</pre>
			<pre class="Result"><%= 15.Minutes().FromNow().ToShortTimeString()%></pre>
		</div>
		
		<a id="FormattingTimeSpans"></a>
		<div class="FeatureSection">
			<h3>Formatting <span class="Class">TimeSpans</span></h3>
			<p>Time since the beginning of the calendar year:</p>
			
			<pre class="Source">String.Format(new TimeSpanFormatProvider(), 
	"{0:d} days, {0:h} hours, {0:m} minutes, and {0:s} seconds", 
	DateTime.Now - new DateTime(DateTime.Today.Year, 1, 1))</pre>
			<pre class="Result"><%= 
				String.Format(new TimeSpanFormatProvider(), 
			        "{0:d} days, {0:h} hours, {0:m} minutes, and {0:s} seconds", 
					DateTime.Now - new DateTime(DateTime.Today.Year, 1, 1)) %></pre>
			
			<p>Time until the end of the calendar year:</p>
			<pre class="Source">String.Format(new TimeSpanFormatProvider(), 
	"{0:dd:hh:mm:ss}", 
	new DateTime(DateTime.Today.Year + 1, 1, 1) - DateTime.Now)</pre>
			<pre class="Result"><%= 
				String.Format(new TimeSpanFormatProvider(), 
			        "{0:dd:hh:mm:ss}", 
					new DateTime(DateTime.Today.Year + 1, 1, 1) - DateTime.Now) %></pre>
		</div>
    </form>
    <script type="text/javascript">
    	function googleOnLoad() {
    		var pageRequestManager = Sys.WebForms.PageRequestManager.getInstance();

    		pageRequestManager.add_initializeRequest(InitializeRequest);
    		pageRequestManager.add_endRequest(EndRequest);

    		$(function() {
    			// ScrollTo doesn't seem to work well with mobile Safari
				if(!navigator.userAgent.match(/iPhone|iPad|iPod/i)) {
				
    				$.getScript("Scripts/jquery.scrollTo-min.js", function() {
	    				$('#DemoList a').click(function(event) {
	    					$.scrollTo($($(this).attr('href')), 500, { 'easing': 'swing' });

	    					event.preventDefault();
	    				});
	    			});
				}

    			$('#RelativetimeExamples li').wrapInner(
					$('<a href="#" />').click(function(event) {
						$('#RelativeTimeExpression').val($(this).text());
						__doPostBack('Parse', '');

						event.preventDefault();
					})
				);
    		});
    	}

    	function InitializeRequest(sender, args) {
    		$('#RelativeTimeContainer').addClass('InProgress');
    		$('#Parse').attr('disabled', 'disabled');
    	}

    	function EndRequest(sender, args) {
    		$('#RelativeTimeContainer').removeClass('InProgress');
    		$('#Parse').removeAttr('disabled');
    	}

    	google.load("jquery", "1");
    	google.setOnLoadCallback(googleOnLoad);
    </script>
	<script type="text/javascript" src="http://www.google-analytics.com/ga.js"></script>
	<script type="text/javascript">
		/* <![CDATA[ */
		try {
		pageTracker = _gat._getTracker("UA-7004300-1");
		pageTracker._trackPageview();
		} catch(err) {}

	/* ]]> */
	</script>
</body>
</html>