
function writeCardSize (size)
{
  if (navigator.userAgent.indexOf('MSIE') > 0) {
    document.write(size);
  } else {
    if (size == "xx-small") {
      document.write("x-small");
    } else if (size == "x-small") {
      document.write("small");
    } else if (size == "small") {
      document.write("medium");
    } else if (size == "medium") {
      document.write("large");
    } else if (size == "large") {
      document.write("x-large");
    } else if (size == "x-large") {
      document.write("xx-large");
    } else if (size == "xx-large") {
      document.write("xx-large");
    } else {
      document.write("small");
    }
  }
}

document.write('<table width="100%" border="0" cellspacing="0" cellpadding="3"><tr><td align="left" valign="top" width="50%"><b><font size="2">Complete these beginnings...</font></b></td><td align="left" valign="top" width="50%"><b><font size="2">by dragging these endings.</font></b></td></tr></table>');

document.write('<div id="dragdropdiv"/><!-- needed in order calculate where the question squares begin --><table width="100%" border="0" cellspacing="1" cellpadding="10" bgcolor="silver"><tr><td align="center" valign="top" bgcolor="white">');

document.write('<style type="text/css">');
document.write('div.CardStyleF { position: absolute; font-family: Lucida Grande, Arial Unicode MS, Sans Serif; font-size: ');
writeCardSize(optionCardFontSize);
document.write('; padding: 8px; border-style: solid; border-width: 1px; color: #333333; background-color: #eeeeee; left: -50px; top: -50px; overflow: visible; text-align: right; }');
document.write('    div.CardStyleD { position: absolute; font-family: Lucida Grande, Arial Unicode MS, Sans Serif; font-size: ');
writeCardSize(optionCardFontSize);
document.write('; padding: 8px; border-style: solid; border-width: 1px; color: #333333; background-color: #eeeeee; left: -50px; top: -50px; overflow: visible; text-align: left; }');
document.write('</style>');

///////////////////////////////////////////////////////////
//
// **** NO NEED TO MODIFY ANYTHING BELOW THIS POINT *******
//
///////////////////////////////////////////////////////////

var SafariPixels = 18;  // try 24, 12, 6 also
var OtherBrowserPixels = 18;  // Non-IE browsers

F = new Array();
D = new Array();

F.length = questions.length;
D.length = answers.length;

for (i=0; i<F.length; i++){
  F[i] = new Array();
  F[i][0] = questions[i];
  F[i][1] = i+1;
}

for (i=0; i<D.length; i++){
  D[i] = new Array();
  D[i][0] = answers[i];
  D[i][1] = i+1;
  D[i][2] = 0;
}



function Client(){
//if not a DOM browser, hopeless
	this.min = false; if (document.getElementById){this.min = true;};

	this.ua = navigator.userAgent;
	this.name = navigator.appName;
	this.ver = navigator.appVersion;  

//Get data about the browser
	this.mac = (this.ver.indexOf('Mac') != -1);
	this.win = (this.ver.indexOf('Windows') != -1);

//Look for Gecko
	this.gecko = (this.ua.indexOf('Gecko') > 1);
	if (this.gecko){
		this.geckoVer = parseInt(this.ua.substring(this.ua.indexOf('Gecko')+6, this.ua.length));
		if (this.geckoVer < 20020000){this.min = false;}
	}
	
//Look for Firebird
	this.firebird = (this.ua.indexOf('Firebird') > 1);
	
//Look for Safari
	this.safari = (this.ua.indexOf('Safari') > 1);
	if (this.safari){
		this.gecko = false;
	}
	
//Look for IE
	this.ie = (this.ua.indexOf('MSIE') > 0);
	if (this.ie){
		this.ieVer = parseFloat(this.ua.substring(this.ua.indexOf('MSIE')+5, this.ua.length));
		if (this.ieVer < 5.5){this.min = false;}
	}
	
//Look for Opera
	this.opera = (this.ua.indexOf('Opera') > 0);
	if (this.opera){
		this.operaVer = parseFloat(this.ua.substring(this.ua.indexOf('Opera')+6, this.ua.length));
		if (this.operaVer < 7.04){this.min = false;}
	}
	if (this.min == false){
		alert('Your browser may not be able to handle this page.');
	}
	
//Special case for the horrible ie5mac
	this.ie5mac = (this.ie&&this.mac&&(this.ieVer<6));
}

var C = new Client();



//CODE FOR HANDLING NAV BUTTONS AND FUNCTION BUTTONS

//[strNavBarJS]
function NavBtnOver(Btn){
	if (Btn.className != 'NavButtonDown'){Btn.className = 'NavButtonUp';}
}

function NavBtnOut(Btn){
	Btn.className = 'NavButton';
}

function NavBtnDown(Btn){
	Btn.className = 'NavButtonDown';
}
//[/strNavBarJS]

function FuncBtnOver(Btn){
	if (Btn.className != 'FuncButtonDown'){Btn.className = 'FuncButtonUp';}
}

function FuncBtnOut(Btn){
	Btn.className = 'FuncButton';
}

function FuncBtnDown(Btn){
	Btn.className = 'FuncButtonDown';
}

function FocusAButton(){
	if (document.getElementById('CheckButton1') != null){
		document.getElementById('CheckButton1').focus();
	}
	else{
		if (document.getElementById('CheckButton2') != null){
			document.getElementById('CheckButton2').focus();
		}
		else{
			document.getElementsByTagName('button')[0].focus();
		}
	}
}




//CODE FOR HANDLING DISPLAY OF POPUP FEEDBACK BOX

var topZ = 1000;

function ShowMessage(Feedback){
  document.getElementById('EvalTextarea').value = Feedback;
}



//GENERAL UTILITY FUNCTIONS AND VARIABLES

//PAGE DIMENSION FUNCTIONS
function PageDim(){
//Get the page width and height
	this.W = 800;
	this.H = 600;
  if (document.getElementsByTagName('body')[0].clientWidth) {
    this.W = document.getElementsByTagName('body')[0].clientWidth;
  } else {
    // For Netscape 6
    if (self.innerWidth) {
      this.W = self.innerWidth;
    }
  }
  if (document.getElementsByTagName('body')[0].clientHeight) {
    this.H = document.getElementsByTagName('body')[0].clientHeight;
  } else {
    // For Netscape 6
    if (self.innerHeight) {
      this.H = self.innerHeight;
    }
  }
}

var pg = null;

function GetPageXY(El) {
	var XY = {x: 0, y: 0};
	while(El){
		XY.x += El.offsetLeft;
		XY.y += El.offsetTop;
		El = El.offsetParent;
	}
	return XY;
}

function GetScrollTop(){
	if (document.documentElement && document.documentElement.scrollTop){
		return document.documentElement.scrollTop;
	}
	else{
		if (document.body){
 			return document.body.scrollTop;
		}
		else{
			return window.pageYOffset;
		}
	}
}

function GetViewportHeight(){
	if (window.innerHeight){
		return window.innerHeight;
	}
	else{
		return document.getElementsByTagName('body')[0].clientHeight;
	}
}

function TopSettingWithScrollOffset(TopPercent){
	var T = Math.floor(GetViewportHeight() * (TopPercent/100));
	return GetScrollTop() + T; 
}

//CODE FOR AVOIDING LOSS OF DATA WHEN BACKSPACE KEY INVOKES history.back()
var InTextBox = false;

function SuppressBackspace(e){ 
	if (InTextBox == true){return;}
	if (C.ie) {
		thisKey = window.event.keyCode;
	}
	else {
		thisKey = e.keyCode;
	}

	var Suppress = false;

	if (thisKey == 8) {
		Suppress = true;
	}

	if (Suppress == true){
		if (C.ie){
			window.event.returnValue = false;	
			window.event.cancelBubble = true;
		}
		else{
			e.preventDefault();
		}
	}
}

if (C.ie){
	document.attachEvent('onkeydown',SuppressBackspace);
	window.attachEvent('onkeydown',SuppressBackspace);
}
else{
	window.addEventListener('keypress',SuppressBackspace,false);
}

function ReduceItems(InArray, ReduceToSize){
	var ItemToDump=0;
	var j=0;
	while (InArray.length > ReduceToSize){
		ItemToDump = Math.floor(InArray.length*Math.random());
		InArray.splice(ItemToDump, 1);
	}
}

function Shuffle(InArray){
	var Num;
	var Temp = new Array();
	var Len = InArray.length;

	var j = Len;

	for (var i=0; i<Len; i++){
		Temp[i] = InArray[i];
	}

	for (i=0; i<Len; i++){
		Num = Math.floor(j  *  Math.random());
		InArray[i] = Temp[Num];

		for (var k=Num; k < (j-1); k++) {
			Temp[k] = Temp[k+1];
		}
		j--;
	}
	return InArray;
}

function WriteToInstructions(Feedback) {
	document.getElementById('InstructionsDiv').innerHTML = Feedback;

}




function EscapeDoubleQuotes(InString){
	return InString.replace(/"/g, '&quot;')
}

function TrimString(InString){
        var x = 0;

        if (InString.length != 0) {
                while ((InString.charAt(InString.length - 1) == '\u0020') || (InString.charAt(InString.length - 1) == '\u000A') || (InString.charAt(InString.length - 1) == '\u000D')){
                        InString = InString.substring(0, InString.length - 1)
                }

                while ((InString.charAt(0) == '\u0020') || (InString.charAt(0) == '\u000A') || (InString.charAt(0) == '\u000D')){
                        InString = InString.substring(1, InString.length)
                }

                while (InString.indexOf('  ') != -1) {
                        x = InString.indexOf('  ')
                        InString = InString.substring(0, x) + InString.substring(x+1, InString.length)
                 }

                return InString;
        }

        else {
                return '';
        }
}

function FindLongest(InArray){
	if (InArray.length < 1){return -1;}

	var Longest = 0;
	for (var i=1; i<InArray.length; i++){
		if (InArray[i].length > InArray[Longest].length){
			Longest = i;
		}
	}
	return Longest;
}

//UNICODE CHARACTER FUNCTIONS
function IsCombiningDiacritic(CharNum){
	var Result = (((CharNum >= 0x0300)&&(CharNum <= 0x370))||((CharNum >= 0x20d0)&&(CharNum <= 0x20ff)));
	Result = Result || (((CharNum >= 0x3099)&&(CharNum <= 0x309a))||((CharNum >= 0xfe20)&&(CharNum <= 0xfe23)));
	return Result;
}

function IsCJK(CharNum){
	return ((CharNum >= 0x3000)&&(CharNum < 0xd800));
}

//SETUP FUNCTIONS
//BROWSER WILL REFILL TEXT BOXES FROM CACHE IF NOT PREVENTED
function ClearTextBoxes(){
	var NList = document.getElementsByTagName('input');
	for (var i=0; i<NList.length; i++){
		if ((NList[i].id.indexOf('Guess') > -1)||(NList[i].id.indexOf('Gap') > -1)){
			NList[i].value = '';
		}
		if (NList[i].id.indexOf('Chk') > -1){
			NList[i].checked = '';
		}
	}
}

//EXTENSION TO ARRAY OBJECT
function Array_IndexOf(Input){
	var Result = -1;
	for (var i=0; i<this.length; i++){
		if (this[i] == Input){
			Result = i;
		}
	}
	return Result;
}
Array.prototype.indexOf = Array_IndexOf;

//IE HAS RENDERING BUG WITH BOTTOM NAVBAR
function RemoveBottomNavBarForIE(){
	if ((C.ie)&&(document.getElementById('Reading') != null)){
		if (document.getElementById('BottomNavBar') != null){
			document.getElementById('TheBody').removeChild(document.getElementById('BottomNavBar'));
		}
	}
}




//HOTPOTNET-RELATED CODE

var HPNStartTime = (new Date()).getTime();
var SubmissionTimeout = 10000;
var Detail = ''; //Global that is used to submit tracking data

function Finish(){
//If there's a form, fill it out and submit it
	if (document.store != null){
		Frm = document.store;
		Frm.starttime.value = HPNStartTime;
		Frm.endtime.value = (new Date()).getTime();
		Frm.mark.value = Score;
		Frm.detail.value = Detail;
		Frm.submit();
	}
}



function Card(ID, OverlapTolerance){
	this.elm=document.getElementById(ID);
	this.name=ID;
	this.css=this.elm.style;
	this.elm.style.left = 0 +'px';
	this.elm.style.top = 0 +'px';
	this.HomeL = 0;
	this.HomeT = 0;
	this.tag=-1;
	this.index=-1;
	this.OverlapTolerance = OverlapTolerance;
}

function CardGetL(){return parseInt(this.css.left)}
Card.prototype.GetL=CardGetL;

function CardGetT(){return parseInt(this.css.top)}
Card.prototype.GetT=CardGetT;

function CardGetW(){return parseInt(this.elm.offsetWidth)}
Card.prototype.GetW=CardGetW;

function CardGetH(){return parseInt(this.elm.offsetHeight)}
Card.prototype.GetH=CardGetH;

function CardGetB(){return this.GetT()+this.GetH()}
Card.prototype.GetB=CardGetB;

function CardGetR(){return this.GetL()+this.GetW()}
Card.prototype.GetR=CardGetR;

function CardSetL(NewL){this.css.left = NewL+'px'}
Card.prototype.SetL=CardSetL;

function CardSetT(NewT){this.css.top = NewT+'px'}
Card.prototype.SetT=CardSetT;

function CardSetW(NewW){this.css.width = NewW+'px'}
Card.prototype.SetW=CardSetW;

function CardSetH(NewH){this.css.height = NewH+'px'}
Card.prototype.SetH=CardSetH;

function CardInside(X,Y){
	var Result=false;
	if(X>=this.GetL()){if(X<=this.GetR()){if(Y>=this.GetT()){if(Y<=this.GetB()){Result=true;}}}}
	return Result;
}
Card.prototype.Inside=CardInside;

function CardSwapColours(){
	var c=this.css.backgroundColor;
	this.css.backgroundColor=this.css.color;
	this.css.color=c;
}
Card.prototype.SwapColours=CardSwapColours;

function CardHighlight(){
	this.css.backgroundColor='#333333';
	this.css.color='#eeeeee';
}
Card.prototype.Highlight=CardHighlight;

function CardUnhighlight(){
	this.css.backgroundColor='#eeeeee';
	this.css.color='#333333';
}
Card.prototype.Unhighlight=CardUnhighlight;

function CardOverlap(OtherCard){
	var smR=(this.GetR()<(OtherCard.GetR()+this.OverlapTolerance))? this.GetR(): (OtherCard.GetR()+this.OverlapTolerance);
	var lgL=(this.GetL()>OtherCard.GetL())? this.GetL(): OtherCard.GetL();
	var HDim=smR-lgL;
	if (HDim<1){return 0;}
	var smB=(this.GetB()<OtherCard.GetB())? this.GetB(): OtherCard.GetB();
	var lgT=(this.GetT()>OtherCard.GetT())? this.GetT(): OtherCard.GetT();
	var VDim=smB-lgT;
	if (VDim<1){return 0;}
	return (HDim*VDim);	
}
Card.prototype.Overlap=CardOverlap;

function CardDockToR(OtherCard){
	this.SetL(OtherCard.GetR() + 5);
	this.SetT(OtherCard.GetT());
}

Card.prototype.DockToR=CardDockToR;

function CardSetHome(){
	this.HomeL=this.GetL();
	this.HomeT=this.GetT();
}
Card.prototype.SetHome=CardSetHome;

function CardGoHome(){
	this.SetL(this.HomeL);
	this.SetT(this.HomeT);
}

Card.prototype.GoHome=CardGoHome;


function doDrag(e) {
	if (CurrDrag == -1) {return};
	if (C.ie){var Ev = window.event}else{var Ev = e}
	var difX = Ev.clientX-window.lastX; 
	var difY = Ev.clientY-window.lastY; 
	var newX = DC[CurrDrag].GetL()+difX; 
	var newY = DC[CurrDrag].GetT()+difY; 
	DC[CurrDrag].SetL(newX); 
	DC[CurrDrag].SetT(newY);
	window.lastX = Ev.clientX; 
	window.lastY = Ev.clientY; 
	return false;
} 

function beginDrag(e, DragNum) { 
	CurrDrag = DragNum;
	if (C.ie){
		var Ev = window.event;
		document.onmousemove=doDrag;
		document.onmouseup=endDrag;
	}
	else{
		var Ev = e;
		window.onmousemove=doDrag; 
		window.onmouseup=endDrag;
	} 
	DC[CurrDrag].Highlight();
	topZ++;
	DC[CurrDrag].css.zIndex = topZ;
	window.lastX=Ev.clientX; 
	window.lastY=Ev.clientY;
	return false;  
} 

function endDrag(e) { 
	if (CurrDrag == -1) {return};
	DC[CurrDrag].Unhighlight();
	if (C.ie){document.onmousemove=null}else{window.onmousemove=null;}
	onEndDrag();	
	CurrDrag = -1;
	return true;
} 

var CurrDrag = -1;
var topZ = 100;




var CorrectResponse = 'Well done!';
var IncorrectResponse = 'Sorry!  Try again.  Incorrect matches have been removed.';
var YourCurrentScoreIs = 'Your current score averaging the total number of attempts is:';
var YourTotalScoreIs = 'Your total score averaging the total number of attempts is:';
var YouAchievedAll = 'You have achieved 100%!';
var DivWidth = 600; //default value
var Penalties = 0;
var Score = 0;
var TimeOver = false;
var Locked = false;
var ShuffleQs = 0;
var QsToShow = 1001;

var DragWidth = 200;
var LeftColPos = 100;
var RightColPos = 500;
var DragTop = 120;
var Finished = false;

//Fixed and draggable card arrays
FC = new Array();
DC = new Array();

function onEndDrag(){ 
//Is it dropped on any of the fixed cards?
	var Docked = false;
	var DropTarget = DroppedOnFixed(CurrDrag);
	if (DropTarget > -1){
//If so, send home any card that is currently docked there
		for (var i=0; i<DC.length; i++){
			if (DC[i].tag == DropTarget+1){
				DC[i].GoHome();
				DC[i].tag = 0;
				D[i][2] = 0;
			}
		}
//Dock the dropped card
		DC[CurrDrag].DockToR(FC[DropTarget]);
		D[CurrDrag][2] = F[DropTarget][1];
		DC[CurrDrag].tag = DropTarget+1;
		Docked = true;
	}

	if (Docked == false){
		DC[CurrDrag].GoHome();
		DC[CurrDrag].tag = 0;
		D[CurrDrag][2] = 0;
	}
} 

function DroppedOnFixed(DNum){
	var Result = -1;
	var OverlapArea = 0;
	var Temp = 0;
	for (var i=0; i<FC.length; i++){
		Temp = DC[DNum].Overlap(FC[i]);
		if (Temp > OverlapArea){
			OverlapArea = Temp;
			Result = i;
		}
	}
	return Result;
}


function StartUp()
{
//Initialize/reset everything
    document.getElementById('EvalTextarea').value = "";
    Penalties = 0;
    Score = 0;
    TimeOver = false;
    Locked = false;
    ShuffleQs = 0;
    QsToShow = 1001;
    Finished = false;
    for (i=0; i<D.length; i++){
      D[i][2] = 0;
    }

//Calculate page dimensions and positions
	pg = new PageDim();
	DivWidth   = Math.floor(pg.W*0.975);
  LeftColPos = Math.floor(pg.W/37.5);
	DragWidth  = Math.floor((DivWidth*2.6)/10);

	RightColPos = pg.W - (DragWidth + LeftColPos);
	DragTop = parseInt(document.getElementById('dragdropdiv').offsetTop) + 10;

//Reduce array if required
	if (QsToShow < F.length){
		ReduceItems2();
	}
	
//Shuffle the left items if required
	if (ShuffleQs == true){
		F = Shuffle(F);
	}

//Shuffle the items on the right
	D = Shuffle(D);

	var CurrTop = DragTop;
	var TempInt = 0;
	var DropHome = 0;
	var Widest = 0;
	var CardContent = '';
	for (var i=0; i<F.length; i++){
		CardContent = F[i][0];
		FC[i] = new Card('F' + i, 10);
		FC[i].elm.innerHTML = CardContent;
		if (FC[i].GetW() > Widest){
			Widest = FC[i].GetW();
      if (C.gecko||C.ie5mac){Widest -= OtherBrowserPixels;}
      if (C.safari){Widest -= SafariPixels;}
		}
	}
	if (Widest > DragWidth){Widest = DragWidth;}
	CurrTop = DragTop;

	DragWidth = Math.floor((DivWidth-Widest)/2.4);
  if (C.ie){DragWidth += 15;}
  if (C.gecko||C.ie5mac){DragWidth -= OtherBrowserPixels;}
  if (C.safari){DragWidth -= SafariPixels;}
	RightColPos = DivWidth + LeftColPos - (DragWidth + 30);
  if (C.gecko||C.ie5mac){RightColPos -= OtherBrowserPixels;}
  if (C.safari){RightColPos -= SafariPixels;}
  if (C.ie){RightColPos += 15;}


	var Highest = 0;
	var WidestRight = 0;

	for (i=0; i<D.length; i++){
		DC[i] = new Card('D' + i, 10);
		CardContent = D[i][0];
//		if (CardContent.indexOf('<img ') > -1){CardContent += '<br clear="all" />';} //used to be required for Navigator rendering bug with images
		DC[i].elm.innerHTML = CardContent; 
		if (DC[i].GetW() > DragWidth){DC[i].SetW(DragWidth);}
		DC[i].css.cursor = 'move';
		DC[i].css.backgroundColor = '#eeeeee';
		DC[i].css.color = '#333333';
		TempInt = DC[i].GetH();
		if (TempInt > Highest){Highest = TempInt;}
		TempInt = DC[i].GetW();
		if (TempInt > WidestRight){WidestRight = TempInt;}
	}

	var HeightToSet = Highest;
	if (C.gecko||C.ie5mac){HeightToSet -= OtherBrowserPixels;}
	if (C.safari){HeightToSet -= SafariPixels;}
	var WidthToSet = WidestRight;
	if (C.gecko||C.ie5mac){WidthToSet -= OtherBrowserPixels;}
	if (C.safari){WidthToSet -= SafariPixels;}

	for (i=0; i<D.length; i++){
		DC[i].SetT(CurrTop);
		DC[i].SetL(RightColPos);
		if (DC[i].GetW() < WidestRight){
			DC[i].SetW(WidthToSet);
		}
		if (DC[i].GetH() < Highest){
			DC[i].SetH(HeightToSet);
		}
		DC[i].SetHome();
		DC[i].tag = -1;
		CurrTop = CurrTop + DC[i].GetH() + 5;
	}

	CurrTop = DragTop;

  for (var i=0; i<F.length; i++){
		FC[i].SetW(Widest);
		if (FC[i].GetH() < Highest){
			FC[i].SetH(HeightToSet);
		}
		FC[i].SetT(CurrTop);
		FC[i].SetL(LeftColPos);
		FC[i].SetHome();
		TempInt = FC[i].GetH();
		CurrTop = CurrTop + TempInt + 5;
	}

  // Calc where to start the evaluate/reset buttons and textarea
  var ExtraSpaceOffset = 10;
	if (C.gecko||C.ie5mac){ExtraSpaceOffset -= 10;}
  document.getElementById('evaluatetopdiv').style.height = CurrTop - DragTop + ExtraSpaceOffset;

}


function ReduceItems2(){
	var ItemToDump=0;
	var j=0;
	while (F.length > QsToShow){
		ItemToDump = Math.floor(F.length*Math.random());
		for (j=ItemToDump; j<(F.length-1); j++){
			F[j] = F[j+1];
		}
		for (j=ItemToDump; j<(D.length-1); j++){
			D[j] = D[j+1];
		}		
		F.length = F.length-1;
		D.length = D.length-1;
	}
}

function TimerStartUp(){
	setTimeout('StartUp()', 300);
}

function CheckAnswers(){
	if (Locked == true){return;}

  nullcount = 0;
  for (i=0; i<D.length; i++){
    if (D[i][2] <= 0){
      nullcount++;
    }
  }

  if (nullcount > 0) {
    ShowMessage("Please answer all questions before checking your answers!");
  } else {

    //Set the default score and response
    var TotalCorrect = 0;
    Score = 0;
    var Feedback = '';

    //for each fixed, check to see if the tag value for the draggable is the same as the fixed
    var i, j;
    for (i=0; i<D.length; i++){
      if ((D[i][2] == D[i][1])&&(D[i][2] > 0)){
        TotalCorrect++;
      }
      else{
        DC[i].GoHome();
        D[i][2] = 0;
      }
    }

    if (F.length > 0) {
      Score = Math.floor((100*(TotalCorrect-Penalties))/F.length);
    } else {
      Score = 100;
    }
    var AllDone = false;

    if (TotalCorrect == F.length) {
      AllDone = true;
    }

    if (AllDone == true){
      Feedback = YouAchievedAll + "  " + YourTotalScoreIs + ' ' + Score + '%.';
      ShowMessage(Feedback + '\r' + CorrectResponse);
    }
    else {
      Feedback = IncorrectResponse + '\r' + YourCurrentScoreIs + ' ' + Score + '%.';
      ShowMessage(Feedback);
      Penalties++; // Penalty for inaccurate check
    }
    //If the exercise is over, deal with that
    if ((AllDone == true)||(TimeOver == true)){
      TimeOver = true;
      Locked = true;
      Finished = true;
      setTimeout('Finish()', SubmissionTimeout);
    }
  }
}




//document.write('</head>');


document.write('<body onload="TimerStartUp()" id="TheBody"><!-- BeginTopNavButtons --><!-- EndTopNavButtons --><div class="Titles"><h2 class="ExerciseTitle"></h2><h3 class="ExerciseSubtitle"></h3></div>');


for (var i=0; i<F.length; i++){
	document.write('<div id="F' + i + '" class="CardStyleF"></div>');
}

for (var i=0; i<D.length; i++){
	document.write('<div id="D' + i + '" class="CardStyleD" onmousedown="beginDrag(event, ' + i + ')"></div>');
}


document.write('<div id="evaluatetopdiv" align="center">&nbsp;</div><div id="evaluatebottomdiv" align="center"><br /><input type="button" value="Check Answers" onClick="CheckAnswers()"/><input type="button" value="Reset" onclick="StartUp()"/><br /><br /><textarea id="EvalTextarea" rows="6" cols="47" name="evaluation"></textarea></div>');


document.write('</td></tr></table></div><!-- needed in order to calculate where the question squares begin -->');


StartUp();
