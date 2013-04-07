
// **** NO NEED TO MODIFY ANYTHING BELOW THIS POINT *******

function Is ()
{   // convert all characters to lowercase to simplify testing
    var agt=navigator.userAgent.toLowerCase()

    // *** BROWSER VERSION ***
    this.major = parseInt(navigator.appVersion)

    this.nav  = ((agt.indexOf('mozilla')!=-1) && ((agt.indexOf('spoofer')==-1)
                && (agt.indexOf('compatible') == -1)))
    this.nav4 = (this.nav && (this.major == 4))
    this.nav4up = this.nav && (this.major >= 4)
    this.nav5up = this.nav && (this.major >= 5)

    this.ie   = (agt.indexOf("msie") != -1)
    this.ie4  = (this.ie && (this.major == 4))
    this.ie4up  = this.ie  && (this.major >= 4)
}
var is = new Is();

function maketheBalloon(id, width, message)
{
   var theString = '<STYLE TYPE="text/css">#'+id+'{width:'+width+';}</STYLE>';
   theString+='<DIV CLASS="balloon" id="'+id+'">'+message+'</DIV>';
   document.write(theString);
}

function makeItVisible(event, answerletter)
{
  if (bOnePerPage) {
    answerletter = String.fromCharCode('a'.charCodeAt(0) + giCurrentItem);
  }
  if (document.layers) {
    document.layers[answerletter].left = event.pageX + 10;
    document.layers[answerletter].top = event.pageY + 10;
    document.layers[answerletter].visibility="show";
  } else if (document.all) {
    document.all[answerletter].style.pixelLeft = (document.body.scrollLeft +event.clientX) + 10;
    document.all[answerletter].style.pixelTop = (document.body.scrollTop + event.clientY) + 10;
    document.all[answerletter].style.visibility="visible";
  } else {
    if (window.pageXOffset >= 0) {
      document.getElementById(answerletter).style.left = window.pageXOffset + event.clientX + 10 + "px";
      document.getElementById(answerletter).style.top = window.pageYOffset + event.clientY + 10 + "px";
    } else {
      document.getElementById(answerletter).style.left = (document.body.scrollLeft +event.clientX) + 10;
      document.getElementById(answerletter).style.top = (document.body.scrollTop + event.clientY) + 10;
    }
    document.getElementById(answerletter).style.visibility="visible";
  }
}

function hideHelp(answerletter)
{
  if (bOnePerPage) {
    answerletter = String.fromCharCode('a'.charCodeAt(0) + giCurrentItem);
  }
  if (document.layers) {
    document.layers[answerletter].visibility="hide";
  } else if (document.all) {
    document.all[answerletter].style.visibility="hidden";
  } else {
    document.getElementById(answerletter).style.visibility="hidden";
  }
}


function drawTextBox(index, width, height)
{
  textboxtext = "";
  if (index == 0) {
    var iAnswerEnds = answers[index].indexOf('[');
    if (iAnswerEnds==-1) {
      iAnswerEnds = answers[index].length;
    }
    textboxtext = answers[index].substring(0, iAnswerEnds);
  }

  if (width <= 0) {
    width = 47;
  }
  if (height <= 0) {
    height = 7;
  }

  document.write('<table border="0" cellpadding="0" cellspacing="2"><tr><td><textarea id="ctaFeedback" cols="' + width + '" rows="' + height + '">' + textboxtext + '</textarea></td>');
}


function writeSingleQuestionAnswer(index)
{
  if (headers[index].length > 0) {
    bgcolor = "e6e6fa";
    if (index == 0) {
      bgcolor = "eeeeee";
    }
    document.write('<font size="2"><br><br></font><table border="0" cellpadding="3" cellspacing="1" width="95%" bgcolor="#a9a9a9"><tr><td align="left" valign="top" bgcolor="#' + bgcolor + '"><font size="2"><b>' + headers[index] + '</b></font></td></tr></table>');
  }

  if (index == 0) {
    document.write('<font size="2"><br></font><table border="0" cellpadding="4" cellspacing="0" width="65%"><tr><td colspan="2" valign="top" align="left" nowrap><font size="1" color="gray"><i>(First, read the sentences below and think of a way to combine them into one sentence.)</i></font></td></tr></table>');
  }

  document.write('<font size="2"><br></font><table border="0" cellpadding="4" cellspacing="0" width="65%"><tr><td valign="top" align="right" nowrap width="22"><font size="2"><b>');
  if (bShowQuestionNumbers == true) {
    document.write(index + '.');
  }
  document.write('</b></font></td><td valign="top" align="left"><font size="2">' + questions[index] + '</font></td></tr></table><br>');

  if (index == 0) {
    document.write('<table width="60%" border="0" cellspacing="0" cellpadding="0"><tr><td><font size="1" color="gray"><i>(After you decide how to combine the sentences above into one sentence, type your answer here. For example:)</i></font></td></tr></table>');
  }

  drawTextBox(index, aWidth[index], aHeight[index]);

  if (bMouseOverPlaceRight == false) {
    document.write('</tr><tr>');
  }

  answerletter = String.fromCharCode('a'.charCodeAt(0)+index);
  document.write('<td valign="middle" align="center"><table width="100%" border="0" cellspacing="0" cellpadding="0"><tr height="35"><td align="left" valign="top" width="50%" height="35"><a href="#" class="isTip" onmouseover="makeItVisible(event, \'' + answerletter + '\')" onmouseout="hideHelp(\'' + answerletter + '\')"><img src="../../grafix/navigation/mouseovercompare.gif" width="113" height="31" border="0" hspace="12"></a></td></tr>');

  if (index == 0) {
    document.write('<tr><td align="left" valign="top" width="50%"><font size="1" color="gray"><i>(After you type your answer above, move your<br></i></font><font size="1" color="gray"><i>cursor over this graphic to compare your answer<br>with ours.)</i></font></td></tr>');
  }

  document.write('</table></td></tr></table>');
}


function writeBaseQuestionAnswer(index)
{
  if (headers[index].length > 0) {
    document.write('<font size="2"><br><br></font><table border="0" cellpadding="3" cellspacing="1" width="95%" bgcolor="#a9a9a9"><tr><td align="left" valign="top" bgcolor="#e6e6fa"><font size="2"><b><div id="divheader"></b></font></td></tr></table>');
  }

  if (index == 0) {
    document.write('<font size="2"><br></font><table border="0" cellpadding="4" cellspacing="0" width="65%"><tr><td colspan="2" valign="top" align="left" nowrap><font size="1" color="gray"><i><div id="divinstruct1">(First, read the sentences below and think of a way to combine them into one sentence.)</div></i></font></td></tr></table>');
  }

  document.write('<font size="2"><br></font><table border="0" cellpadding="4" cellspacing="0" width="65%"><tr><td valign="top" align="right" nowrap width="22"><font size="2"><b><div id="divnumber"></div></b></font></td><td valign="top" align="left"><font size="2"><div id="divquestion"></div></font></td></tr></table><br>');

  if (index == 0) {
    document.write('<table width="60%" border="0" cellspacing="0" cellpadding="0"><tr><td><font size="1" color="gray"><i><div id="divinstruct2">(After you decide how to combine the sentences above into one sentence, type your answer here. For example:)</div></i></font></td></tr></table>');
  }

  drawTextBox(index, aWidth[index], aHeight[index]);

  if (bMouseOverPlaceRight == false) {
    document.write('</tr><tr>');
  }

  document.write('<td valign="middle" align="center"><table width="100%" border="0" cellspacing="0" cellpadding="0"><tr height="35"><td align="left" width="50%" height="35"><a id="cmoTip" href="#" class="isTip" onmouseover="makeItVisible(event)" onmouseout="hideHelp()"><img src="../../grafix/navigation/mouseovercompare.gif" width="113" height="31" border="0" hspace="12"></a></td></tr>');


  if (index == 0) {
    document.write('<tr><td align="left" valign="top" width="50%"><font size="1" color="gray"><i><div id="divinstruct3">(After you type your answer above, move your</div><br></i></font><font size="1" color="gray"><i><div id="divinstruct4">cursor over this graphic to compare your answer<br>with ours.)</div></i></font></td></tr>');
  }

  document.write('</table></td></tr></table>');
}

function replaceQuestionAnswer(index)
{
  if (headers[index].length > 0) {
    document.getElementById('divheader').innerHTML = headers[index];
  }
  if (index <= 0) {
    document.getElementById('divinstruct1').innerHTML = "";
    document.getElementById('divinstruct2').innerHTML = "";
    document.getElementById('divinstruct3').innerHTML = "";
    document.getElementById('divinstruct4').innerHTML = "";
  }
  if (bShowQuestionNumbers == true) {
    document.getElementById('divnumber').innerHTML = index + '.';
  }
  document.getElementById('divquestion').innerHTML = questions[index];

  if ((aWidth[index].length <= 0) || (aWidth[index] <= 0)) {
    aWidth[index] = 47;
  }
  if ((aHeight[index].length <= 0) || (aHeight[index] <= 0)) {
    aHeight[index] = 7;
  }
  document.getElementById('ctaFeedback').cols = aWidth[index];
  document.getElementById('ctaFeedback').rows = aHeight[index];
}

function gotoNextQues()
{
  if (giCurrentItem < (questions.length-1)) {
    giCurrentItem++;
    replaceQuestionAnswer(giCurrentItem);
    resetForm();
  } else {
    document.getElementById('ctaFeedback').value = "Congratulations, you have completed the exercise.";
    document.getElementById('nextques').disabled = true;
  }
}

function resetForm()
{
  document.getElementById('ctaFeedback').value = "";
}


document.write('<style type="text/css"><!-- .balloon { font-size: 9pt; background-color: #FFFFE0; padding: 7; border: solid thin black; position: absolute; visibility: hidden; layer-background-color: #FFFFE0; } .istip { text-decoration: none } --></style>');


for (i = 0;  i < questions.length;  i++) {
  answerletter = String.fromCharCode('a'.charCodeAt(0) + i);
  maketheBalloon(answerletter, 200, answers[i]);
}

var giCurrentItem = 0;

if ((headers[giCurrentItem].length   <= 0)
||  (questions[giCurrentItem].length <= 0)
||  (answers[giCurrentItem].length   <= 0)) {
  giCurrentItem = 1;
}

if (bOnePerPage) {
  //if (questions.length > 1) {
    writeBaseQuestionAnswer(giCurrentItem);
    replaceQuestionAnswer(giCurrentItem);
    document.write('<br /><input id="nextques" type="button" value="Next Question =&gt;" onclick="gotoNextQues(this.form)"></input>');
  //}
} else {
  while (giCurrentItem < questions.length) {
    writeSingleQuestionAnswer(giCurrentItem);
    giCurrentItem++;
  }
}

document.write('<br /><br />');
