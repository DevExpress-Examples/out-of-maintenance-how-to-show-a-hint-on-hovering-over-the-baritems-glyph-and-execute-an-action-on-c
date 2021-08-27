<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128617587/14.2.10%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/T324294)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [ExampleHelper.cs](./CS/FavoriteList/ExampleHelper.cs) (VB: [ExampleHelper.vb](./VB/FavoriteList/ExampleHelper.vb))
* **[Form1.cs](./CS/FavoriteList/Form1.cs) (VB: [Form1.vb](./VB/FavoriteList/Form1.vb))**
* [Program.cs](./CS/FavoriteList/Program.cs) (VB: [Program.vb](./VB/FavoriteList/Program.vb))
* [ToolTipObject.cs](./CS/FavoriteList/ToolTipObject.cs) (VB: [ToolTipObject.vb](./VB/FavoriteList/ToolTipObject.vb))
<!-- default file list end -->
# How to show a hint on hovering over the BarItem's glyph and execute an action on click


<p>This example demonstrates a possible way of implementing the "<em>Add to Favorites</em>" functionality.<br><br><strong>Possible scenario</strong><br><br>We are developing a chat application using DevExpress <strong>RibbonControl</strong>. Like in the majority of such applications, we have a list of  "<em>Favorite</em>" contacts. So, we would like to have the capability to click on the contact's glyph to add a contact to the list or remove this contact from the list if the list already contains it.</p>
<img src="https://raw.githubusercontent.com/DevExpress-Examples/how-to-show-a-hint-on-hovering-over-the-baritems-glyph-and-execute-an-action-on-click-t324294/14.2.10+/media/84ff6f99-abf1-11e5-80bf-00155d62480c.png"><br><strong>Steps to implement</strong><br>
<p><br><strong>1. </strong>Implement the <a href="https://msdn.microsoft.com/en-us/library/system.windows.forms.imessagefilter(v=vs.110).aspx"><strong>IMessageFilter</strong></a> interface to catch mouse move messages in order to show a tool tip after some time interval has elapsed. <br><br><strong>2.</strong> Implement some functionality which will allow us to know whether or not Cursor is above the the contact's glyph and also to correctly determine a tool tip location. In this example, an approach described in the <a href="https://www.devexpress.com/Support/Center/p/T231975"><strong>BarButtonItem: handling click on image</strong></a><strong> </strong>ticket is used for this purpose.<br><strong><br>3. </strong>Handle the <strong>ItemClick </strong>event for all bar items in the contacts list and design a method (methods) which will add the clicked item to the "<em>Favorites</em>" list if Cursor is above the bar item's glyph or remove the item if the "<em>Favorites</em>" list already contains it.</p>
<br><br>

<br/>


