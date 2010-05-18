#NDueTime
Lightweight date & time library for .NET

##What NDueTime Is Not
*	All-encompassing & sophisticated solution like [NodaTime](http://code.google.com/p/noda-time/)
*	All fluent interfaces all the time like [Fluent DateTime](http://fluentdatetime.codeplex.com/)
*	Generative DateTime solution like [LINQToDateTime](http://github.com/JulianR/LinqToDateTime)

##Relative DateTime creation
Inspired by the Rails time extensions:

	5.Minutes().Ago();
	
##Creating Natural Time Expressions From DateTimes
Humane descriptions of relative times:

	dateTime.ToRelativeTimeString();
	
##Parsing Natural Time Expressions
Not yet implemented, but meant to be similar to Google Calendar's functionality.
	
##Formatting TimeSpans
The DateTime struct has native support for string formatting, but TimeSpan has been left to fend for itself. NDueTime has a CustomFormatProvider for TimeSpans:

	String.Format(new TimeSpanFormatProvider(), "{0:d} days, {0:h} hours, and {0:m} minutes", timeSpan);
	
##Date Range
For when one date isn't enough:

	new DateRange(from, to).Contains(other);