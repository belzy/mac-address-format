# mac-address-format
Application Name: MAC Address Format Tool <br />
Author: Brandon G. Elzy <br />
Date Created: April 11, 2017 <br />
Date Last Modified: April 23, 2017 <br />
Purpose: This application allows a user to enter a 48 bit MAC address string in a number of different formats. <br />
         When the format button is activated, the string is converted into all available MAC Address formats and <br />
         displayed in a text box. The user may copy any of the text from the textbox, but cannot edit the text. <br />

<hr />
<h3>UPDATES:</h3>
<ul>
  <li>Version 1.1</li>
  <li>April 23, 2017</li>
  <li>Added feature where user can enter any of the MAC Address formats as input.</li>
  <li>Optimized runtime by refactoring the input validation and formatting processes.</li>
 </ul>
 <hr />
<h3>BUGS:</h3>
<ul>
  <li>After entering the format (123456-789abc) then adding a character (123456789-abcd)<br />
      the application does not crash but seems to be loading and always displays the invalidMacAddress
      error message.</li>
</ul>
<hr />
<h4>ACCEPTED MAC ADDRESS FORMATS:</h4>
<ul>
  <li>123456789abc</li>
  <li>123456-789abc</li>
  <li>1234.5678.9abc</li>
  <li>12.34.56.78.9a.bc</li>
  <li>12-34-56-78-9a-bc</li>
  <li>12:34:56:78:9a:bc</li>
</ul>
<hr />
