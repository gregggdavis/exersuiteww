
// **** NO NEED TO MODIFY ANYTHING BELOW THIS POINT *******

function choice() {
 for(n=0;n<answers.length;n++)
  eval("document.matching.answer"+n+".checked = false");
 for(n=0;n<questions.length;n++) {
  sel = eval("document.matching.choice"+n+".selectedIndex")-1;
  if (sel >= 0) {
    eval("document.matching.answer"+sel+".checked = true");
  }
 }
}


function gradeQuiz() {
  nullcount = 0;
  for(n=0;n<questions.length;n++) {
    sel = eval("document.matching.choice"+n+".selectedIndex")-1;
    if (sel<0) {
      nullcount++;
    }
  }
  if (nullcount > 0) {
    document.matching.evaluation.value = "Please answer all questions before checking your answers!";
  } else {
    maximum_score = 100;
    penalty_for_wrong_answer = (questions.length > 0) ? (maximum_score / questions.length) : maximum_score;
    correct = questions.length;
    score = maximum_score;
    wrong = "";
    for (n = 0;  n < questions.length;  n++) {
        sel = eval("document.matching.choice" + n + ".selectedIndex") - 1;
        if ((sel < 0) || (alpha.charAt(sel) != questions[n].answer)) {
            correct -= 1;
            score -= penalty_for_wrong_answer;
            wrong += "#" + eval(n+1) + " is incorrect. " + "\r\n";
        }
    }
    document.matching.evaluation.value = "You answered " + correct + " out of " + questions.length + " correctly for a score of " + Math.round(score) + "%.\r\n" + wrong;
  }
}


function ResetEverything() {
 for(n=0;n<answers.length;n++)
  eval("document.matching.answer"+n+".checked = false");
 for(n=0;n<questions.length;n++) {
  eval("document.matching.choice"+n+".selectedIndex = 0");
 }
 eval("document.matching.evaluation.value=''");
}


// Convert questions to a 0-based array
for(iQuesIndex=0;iQuesIndex<questions.length;iQuesIndex++) {
  questions[iQuesIndex] = questions[iQuesIndex + 1];
}
questions[questions.length] = null;


alpha = "abcdefghijklmnopqrstuvwxyz";


answers_menu = "<option>"+""+"</option>";
answers_text = "<td bgcolor=#eeeeee width=50% align=left valign=top cellpadding=3 rowspan="+questions.length+">";
answers_text += "<table>";
for(n=0;n<answers.length;n++) {
  answers_text += "<tr>";
  answers_menu += "<option>"+alpha.charAt(n)+"</option>";
  answers_text += '<td align=left valign=top><input type=checkbox disabled name="answer'+n+'"></td>'+'<td bgcolor=#eeeeee align=right valign=top><font size=2>'
  +alpha.charAt(n)+"."+'</td><td bgcolor=#eeeeee align=left valign=top><font size=2>'+answers[alpha.charAt(n)]+'</td>';
  answers_text += "</tr>"
}
answers_text += "</table></td>";


document.write('<table width="80%" border="0" cellspacing="0" cellpadding="3"><tr><td align="left" valign="top" width="50%"><b><font size="2">Match expressions here...</font></b></td><td align="left" valign="top" width="50%"><b><font size="2">with the answers below.</font></b></td></tr></table>');

document.write('<table width="80%" border="0" cellspacing="1" cellpadding="10" bgcolor="silver"><tr><td align="center" valign="top" bgcolor="white">');

document.write('<center><form name="matching"><table width=100% cellpadding=3 cellspacing=0>');
for(n=0;n<questions.length;n++) {

  extra_spaces = 0;
  if (questions[n].text.length < 40) {
    extra_spaces = 40-questions[n].text.length;
  }

  document.write('<tr><td align=right valign=top width=40><select name="choice'+n+'" size=1 onChange="choice()">'+answers_menu+'</select></td><td width=14 align=right valign=top><font size=2>'+eval(n+1)+'. '
  +'</td><td align=left valign=top><font size=2>'+questions[n].text);
  for (es=0;es<extra_spaces;es++){
    document.write('&nbsp;');
  }
  document.write('</font></td>'+(n==0?answers_text:"")+'</tr>');
}
if (iResultsWidth <= 0) {
  iResultsWidth = 47;
}
if (iResultsHeight <= 0) {
  iResultsHeight = 8;
}
document.write('<tr><td colspan=6><br><center><input type=button value="Check Answers" '
+'onClick="gradeQuiz()"><input type=button value="Reset" onclick="ResetEverything()"><br><br><textarea rows="' + iResultsHeight + '" cols="' + iResultsWidth + '" name="evaluation"></textarea>'
+'</font></td></tr></table></form>');

document.write('</td></tr></table>');


