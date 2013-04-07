// **** NO NEED TO MODIFY ANYTHING BELOW THIS POINT *******

function checkAnswers(form)
{
  var sFeedback = "";

  if (bOnePerPage) {

    var currSelection; 

    var sResponse = "";
    sResponse = "";

    for (j=0; j<numChoi; j++) { 
      currSelection = form.elements[j]; 
      if (currSelection.checked) { 
        if (questions[giCurrentItem][j+1] == answers[giCurrentItem]) { 
          sResponse = "Correct !!!";
        } else {
          sResponse = "Sorry!  Try Again.";
        }
        sFeedback = feedback[giCurrentItem][j];
      } 
    } 

    if (sResponse != "") {
      if (sResponse == "Correct !!!") {
        form.elements['nextques'].disabled = false;
      }
      form.solutions.value = sResponse;
      if (bFeedbackDisplayInResults) {
        form.solutions.value += "\r\r" + sFeedback;
      }
    } else {
      form.solutions.value = "Please answer all questions before checking your answers!";
    }

  } else {

    var score = 0; 
    var currElt; 
    var currSelection; 

    var nullcount = 0;
    var answered = false;
    for (i=0; i<numQues; i++) { 
      currElt = i*numChoi;
      answered = false;
      for (j=0; j<numChoi; j++) { 
        currSelection = form.elements[currElt + j]; 
        if (currSelection.checked) { 
          answered = true;
        }
      } 
      if (answered == false) {
        nullcount++;
      }
    } 

    if ((nullcount > 0) && (bCheckAnswersButton == true)) {
      form.solutions.value = "Please answer all questions before checking your answers!";
    } else {

      var incorrectanswers = "";

      for (i=0; i<numQues; i++) { 
        currElt = i*numChoi; 
        for (j=0; j<numChoi; j++) { 
          currSelection = form.elements[currElt + j]; 
          if (currSelection.checked) { 
          //if (currSelection.value == answers[i]) {   // this line has error - it doesn't check for &quot; type vars - therefore we must use the index of the checked item matched up to the actual question[][] array string
            if (questions[i][j+1] == answers[i]) { 
              score++; 
              if (bCheckAnswersButton == false) {
                incorrectanswers += "\r#" + (i+1) + " is CORRECT!";
              }
              if (bFeedbackDisplayInResults) {
                sFeedback += "\r#" + (i+1) + " is CORRECT!" + "  " + feedback[i][j];
              }
              break; 
            } else {
              incorrectanswers += "\r#" + (i+1) + " is incorrect.";
              if (bFeedbackDisplayInResults) {
                sFeedback += "\r#" + (i+1) + " is incorrect." + "  " + feedback[i][j];
              }
            }
          } 
        } 
      }
      scorepct = 0.0;
      if (numQues > 0) {
        scorepct = Math.round(score/numQues*100);
      }
      form.solutions.value = "You answered " + score + " out of " + numQues + " correctly for a score of " + scorepct + "%.";
      if (bFeedbackDisplayInResults) {
        form.solutions.value += sFeedback;
      } else {
        form.solutions.value += incorrectanswers;
      }

      //if (scorepct >= 100) {
        // Uncomment below 5 lines if you want to show answers after 100%
        //var correctAnswers = ""; 
        //for (i=1; i<=numQues; i++) { 
        //  correctAnswers += i + ". " + answers[i-1] + "\r\n"; 
        //} 
        //form.solutions.value += "\r" + correctAnswers;
      //}

    }
  }
} 



function displayFeedbackAndCheckAnswers(quesNum, choiceNum, form)
{
  if (bFeedbackDisplayInPopup) {
    if (quesNum < 0) {
      quesNum = giCurrentItem;
    }
    alert(feedback[quesNum][choiceNum]);
  }
  if ((bCheckAnswersButton == false) || (bOnePerPage == true)) {
    checkAnswers(form);
  }
}



function writeSingleQuestionAnswer(index)
{
  document.write('<table width="100%" border="0" cellspacing="0" cellpadding="3"><tr><td align="right" valign="top" width="22"><font size="2">');
  document.write((index + 1) + '.');
  document.write('</font></td><td name="tdquestion" align="left" valign="top"><font size="2">');
  document.write(questions[index][0]);
  document.write('<br><br><table width="100%" border="0" cellspacing="0" cellpadding="3">');

  for (iChoice=0; iChoice<numChoi; iChoice++) { 
    document.write('<tr>');
    document.write('  <td align="right" valign="top" width="18"><input type="radio" name="q' + index + 1 + '" value="" onClick="displayFeedbackAndCheckAnswers(' + index + ',' + iChoice + ',this.form)"></td>');
    document.write('  <td align="left" valign="top" width="12"><font size="2">' + String.fromCharCode('a'.charCodeAt(0)+iChoice) + '.</font></td>');
    document.write('  <td align="left" valign="top"><font size="2">' + questions[index][iChoice+1] + '</font></td>');
    document.write('</tr>');
  }

  document.write('</table></font></td></tr></table>');
  document.write('<br />');
}


function writeBaseQuestionAnswer()
{ 
  document.write('<table width="100%" border="0" cellspacing="0" cellpadding="3"><tr><td align="right" valign="top" width="22"><font size="2">');
  document.write('<div id="divnumber"></div>');
  document.write('</font></td><td id="tdquestion" align="left" valign="top"><font size="2">');
  document.write('<div id="divquestion"></div>');
  document.write('<br><br><table width="100%" border="0" cellspacing="0" cellpadding="3">');

  for (iChoice=0; iChoice<numChoi; iChoice++) {
    document.write('<tr>');
    document.write('  <td align="right" valign="top" width="18"><input type="radio" id="q' + iChoice + '" name="q" value="" onClick="displayFeedbackAndCheckAnswers(' + -1 + ',' + iChoice + ',this.form)"></td>');
    document.write('  <td align="left" valign="top" width="12"><font size="2">' + String.fromCharCode('a'.charCodeAt(0)+iChoice) + '.</font></td>');
    document.write('  <td align="left" valign="top"><font size="2">');
    document.write('    <div id="divanswer' + iChoice + '"></div>');
    document.write('</font></td></tr>');
  }

  document.write('</table></font></td></tr></table>');
  document.write('<br />');
}


function replaceQuestionAnswer(index)
{
  document.getElementById('divnumber'  ).innerHTML = (index + 1) + '.';
  if (questions[index]) {
    document.getElementById('divquestion').innerHTML = questions[index][0];
  }

  for (iChoice=0; iChoice<numChoi; iChoice++) { 
    document.getElementById('divanswer' + iChoice).innerHTML = questions[index][iChoice+1];
  }
}


function gotoNextQues(form)
{
  if (giCurrentItem < (numQues-1)) {
    giCurrentItem++;
    replaceQuestionAnswer(giCurrentItem);
    resetForm(form);
  } else {
    form.solutions.value = "Congratulations, you have completed the exercise.";
    form.elements['nextques'].disabled     = true;
    if (bCheckAnswersButton == true) {
      form.elements['checkanswers'].disabled = true;
    }
    form.elements['reset'].disabled        = true;
  }
}


function resetForm(form)
{
  form.solutions.value = "";
  for (iChoice=0; iChoice<numChoi; iChoice++) { 
    document.getElementById('q'         + iChoice).checked = false;
    document.getElementById('divanswer' + iChoice).checked = false;
  }
  form.elements['nextques'].disabled = true;
}



  var giCurrentItem = 0;
  document.write('<form name="quiz"><table width="440" border="0" cellspacing="0" cellpadding="0"><tr><td>');

  if (bOnePerPage) {
      writeBaseQuestionAnswer();
      replaceQuestionAnswer(giCurrentItem);
  } else {
      for (giCurrentItem = 0;  giCurrentItem < numQues;  giCurrentItem++) { 
          writeSingleQuestionAnswer(giCurrentItem);
      }
  }


  document.write('<table border="0" cellspacing="0" cellpadding="3"><tr><td align="left" valign="top">&nbsp;</td><td align="left" valign="top">');

  document.write('<font size="2"><center>');
  if (bCheckAnswersButton == true) {
    document.write('<input type="button" name="checkanswers" value="Check Answers" onClick="checkAnswers(this.form)">');
  }

  if (bOnePerPage) {
    document.write('<input type="button" name="reset" value="Reset" onClick="resetForm(this.form)">');
    document.write('&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input name="nextques" disabled type="button" value="Next Question =&gt;" onclick="gotoNextQues(this.form)"></input>');
  } else {
    document.write('<input type="reset">');
  }

  if (iResultsWidth <= 0) {
    iResultsWidth = 47;
  }
  if (iResultsHeight <= 0) {
    iResultsHeight = 13;
  }

  document.write('</center></font><br />Results:<br /><textarea name="solutions" wrap="virtual" rows="' + iResultsHeight + '" cols="' + iResultsWidth + '"></textarea><br /><!--Score= <input type=text size=6 name="percentage">--></tr></table>');


  document.write('</td></tr></table></form>');
