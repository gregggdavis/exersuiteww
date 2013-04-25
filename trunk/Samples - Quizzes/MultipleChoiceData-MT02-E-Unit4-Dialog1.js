//JSQUIZTYPE=MultipleChoice//JSQUIZTYPEEND
var bOnePerPage=false;
var bFeedbackDisplayInPopup=false;
var bFeedbackDisplayInResults=false;
var bCheckAnswersButton=true;
var iResultsWidth=47;
var iResultsHeight=13;
var numQues=10;
var numChoi=4;
//SIZEVARSBEGIN
numQues=10;
numChoi=4;
//SIZEVARSEND
var answers=new Array(numQues);
var questions=new Array(numQues);
var feedback=new Array(numQues);
for (i=0;i<numQues;i++) {
  questions[i]=new Array(numChoi+1);
  feedback[i]=new Array(numChoi);
}
//questions[][]="";
//QUESTIONSBEGIN
questions[0][0]="When Terry Dobbs refers to &quot;our delegation,&quot; he means";
questions[0][1]="people from your company who will attend the conference.";
questions[0][2]="lobbyists who will represent your company at the conference.";
questions[0][3]="lawyers in Europe who represent companies at conferences.";
questions[0][4]="none of the above.";
questions[1][0]="When Terry told Leslie that you would be in touch &quot;shortly,&quot; he meant";
questions[1][1]="you're not very tall.";
questions[1][2]="you would contact her soon."; 
questions[1][3]="your message would be brief."; 
questions[1][4]="none of the above.";
questions[2][0]="When Terry said you can &quot;get back to her later on that,&quot; he meant"; 
questions[2][1]="return a favor she did for you."; 
questions[2][2]="contact her again after you have more information."; 
questions[2][3]="relieve her of responsibility."; 
questions[2][4]="all of the above.";
questions[3][0]="Leslie Smith is"; 
questions[3][1]="a London lobbyist you sometimes use."; 
questions[3][2]="a member of your global company."; 
questions[3][3]="an independent contractor in England."; 
questions[3][4]="all of the above.";
questions[4][0]="You, Leslie, and Terry are working together to"; 
questions[4][1]="organize a standards conference in Europe."; 
questions[4][2]="hire people to represent you at the conference in Europe."; 
questions[4][3]="put together your company's team for the conference in Europe."; 
questions[4][4]="all of the above.";
questions[5][0]="The person who triggered the cooperative effort was"; 
questions[5][1]="Terry, by contacting you."; 
questions[5][2]="Leslie, by asking Terry who was going to the conference."; 
questions[5][3]="you, by contacting Leslie."; 
questions[5][4]="none of the above.";
questions[6][0]="Your job is to contact Leslie and"; 
questions[6][1]="tell her the known members of the delegation so far."; 
questions[6][2]="ask her if she will be a member of the delegation."; 
questions[6][3]="ask her who else she thinks whould be on the delegation."; 
questions[6][4]="all of the above.";
questions[7][0]="After Leslie responds to your message, Terry wants you to"; 
questions[7][1]="tell him what Leslie says."; 
questions[7][2]="wait for further instructions."; 
questions[7][3]="take the team to Europe."; 
questions[7][4]="none of the above.";
questions[8][0]="When you know the complete makeup of the delegation, Terry wants you to"; 
questions[8][1]="let him know."; 
questions[8][2]="let Leslie know."; 
questions[8][3]="let the conference organizers know."; 
questions[8][4]="none of the above.";
questions[9][0]="You should start your message to Leslie by telling her"; 
questions[9][1]="that Terry asked you to contact her."; 
questions[9][2]="why Terry asked you to contact her."; 
questions[9][3]="that there will be a standards conference in Europe."; 
questions[9][4]="both a and b above.";
//QUESTIONSEND
//answers[]="";
//ANSWERSBEGIN
answers[0]="people from your company who will attend the conference."; 
answers[1]="you would contact her soon."; 
answers[2]="contact her again after you have more information."; 
answers[3]="a member of your global company."; 
answers[4]="put together your company's team for the conference in Europe.";
answers[5]="Leslie, by asking Terry who was going to the conference."; 
answers[6]="all of the above."; 
answers[7]="tell him what Leslie says."; 
answers[8]="let Leslie know."; 
answers[9]="both a and b above."; 
//ANSWERSEND

//feedback[][]="";
//FEEDBACKBEGIN
feedback[0][0]="feedback-people from your \"company\" who will attend the conference.";
feedback[0][1]="feedback-lobbyists who will represent your company at the conference.";
feedback[0][2]="feedback-lawyers in Europe who represent companies at conferences.";
feedback[0][3]="feedback-none of the above.";
feedback[1][0]="feedback-you're not very tall.";
feedback[1][1]="feedback-you would contact her soon.";
feedback[1][2]="feedback-your message would be brief.";
feedback[1][3]="feedback-none of the above.";
feedback[2][0]="feedback-return a favor she did for you.";
feedback[2][1]="feedback-contact her again after you have more information.";
feedback[2][2]="feedback-relieve her of responsibility.";
feedback[2][3]="feedback-all of the above.";
feedback[3][0]="feedback-a London lobbyist you sometimes use.";
feedback[3][1]="feedback-a member of your global company.";
feedback[3][2]="feedback-an independent contractor in England.";
feedback[3][3]="feedback-all of the above.";
feedback[4][0]="feedback-organize a standards conference in Europe.";
feedback[4][1]="feedback-hire people to represent you at the conference in Europe.";
feedback[4][2]="feedback-put together your company's team for the conference in Europe.";
feedback[4][3]="feedback-all of the above.";
feedback[5][0]="feedback-Terry, by contacting you.";
feedback[5][1]="feedback-Leslie, by asking Terry who was going to the conference.";
feedback[5][2]="feedback-you, by contacting Leslie.";
feedback[5][3]="feedback-none of the above.";
feedback[6][0]="feedback-tell her the known members of the delegation so far.";
feedback[6][1]="feedback-ask her if she will be a member of the delegation.";
feedback[6][2]="feedback-ask her who else she thinks whould be on the delegation.";
feedback[6][3]="feedback-all of the above.";
feedback[7][0]="feedback-tell him what Leslie says.";
feedback[7][1]="feedback-wait for further instructions.";
feedback[7][2]="feedback-take the team to Europe.";
feedback[7][3]="feedback-none of the above.";
feedback[8][0]="feedback-let him know.";
feedback[8][1]="feedback-let Leslie know.";
feedback[8][2]="feedback-let the conference organizers know.";
feedback[8][3]="feedback-none of the above.";
feedback[9][0]="feedback-that Terry asked you to contact her.";
feedback[9][1]="feedback-why Terry asked you to contact her.";
feedback[9][2]="feedback-that there will be a standards conference in Europe.";
feedback[9][3]="feedback-both a and b above.";
//FEEDBACKEND

iResultsWidth=47;

iResultsHeight=13;

bOnePerPage=true;

bFeedbackDisplayInPopup=true;

bFeedbackDisplayInResults=true;

bCheckAnswersButton=true;

