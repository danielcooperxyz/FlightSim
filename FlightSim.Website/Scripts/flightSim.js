//-----------------------------------------------------------------------
// <copyright file="flightSim.js" owner="Daniel Cooper">
// Copyright (c) Daniel Cooper. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

var target, startTime, timer, diameterValues, animationTimes, opacityValues;

// Generate a random value for the x position of the target
function getRandomX() {
	var randomInt = Math.random(),
	winWidth = winObj.width();

	return Math.floor(randomInt * winWidth);
}

// Generate a random value for the y position of the target
function getRandomY(){
	var randomInt = Math.random(),
	winHeight = winObj.height();

	return Math.floor(randomInt * winHeight);
}

function parseDateTime(Date)
{
    var dd=Date.getDay();//yields day

    var MM=Date.getMonth();//yields month

    var yyyy=Date.getYear(); //yields year

    var HH=Date.getHours();//yields hours 

    var mm=Date.getMinutes();//yields minutes

    var ss=Date.getSeconds();//yields seconds

    var Time=dd+"/"+MM+"/"+yyyy+" "+HH+':'+mm+':'+ss; 
}

// Set the position of the target
function setPosition(target)
{
	var newCircle,
	randX = getRandomX(),
	randY = getRandomY();

	$('#Experiment_XPosition').val(randX);
	$('#Experiment_YPosition').val(randY);

	target.css('top', randY);
	target.css('left', randX);
}

function parseTargetData()
{
    var radiuses = $('#Experiment_Radiuses').val(),
        opacities = $('#Experiment_Opacities').val(),
        temp;

    radiusKeyVals = radiuses.split("],");
    diameterValues = new Array();
    animationTimes = new Array();

    for (var i = 0; i < radiusKeyVals.length; i++) {
        temp = radiusKeyVals[i].substring(1, radiusKeyVals[i].length).split(",");

        diameterValues[i] = parseFloat(temp[0]) * 2;
        animationTimes[i] = parseInt(temp[1]) * 1000;
    }

    opacityValues = new Array();
    opacities = opacities.split(",");

    for (var i = 0; i < opacities.length; i++) {
        opacityValues[i] = parseFloat(opacities[i]);
    }
}

function setupTarget()
{
    target = $('#template');
    target.css('height', 0);
    target.css('width', 0);
    target.css("opacity", 0);
    target.show();
    setPosition(target);
}

function updateObject()
{
    timer++;

    if (timer < diameterValues.length)
    {
        target.animate({ width: diameterValues[timer].toString() + "px", height: diameterValues[timer].toString() + "px", opacity: opacityValues[timer].toString() }, { duration: animationTimes[timer], complete: updateObject });
    }
}

function postResults()
{
    $('#Experiment_EndTime').val(new Date().getTime());

    $('#experimentResults').submit();
}

$(document).ready(function()
{
	// Remove body margin
	var body = $('body').css('margin', 0),
	object = $('')

	winObj = $(window);

	if ($("#homePage").length > 0)
	{
	    $("#startButton").click(function ()
	    {
	        window.open(experimentUrl, "popUpWindow", "width:600, height: 400, toolbar:no");
	    });
	}
	
	if ($("#experiment").length)
	{
	    winObj.click(postResults);
	    parseTargetData();

	    setupTarget();

        // Begin
	    timer = -1;
	    $('#Experiment_StartTime').val(new Date().getTime());
	    updateObject();
	}
});