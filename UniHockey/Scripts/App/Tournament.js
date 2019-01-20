var defaultValue = '';
var teamsWithPointsBrought;

window.onload = function () {
    callGetPointsBrought(function (result) {
        teamsWithPointsBrought = JSON.parse(result);
    });

    var team1DropDown = document.getElementById('Team1Id');
    team1DropDown.setAttribute('onchange', "updateDropDown('Team1Id')");

    var team2DropDown = document.getElementById('Team2Id');
    team2DropDown.setAttribute('onchange', "updateDropDown('Team2Id')");

    disableSubmitButton();
    setUpDropDownsAndTextboxes();
};

function setUpDropDownsAndTextboxes() {
    var table = document.getElementById('teamsWithPointsTable');

    var dropDowns = table.getElementsByTagName('select');
    var textboxes = table.getElementsByTagName('input');

    disableDropDownsAndTextboxes(dropDowns, textboxes);
    setupEventHandlersForDropDowns(dropDowns, textboxes);
}

function disableDropDownsAndTextboxes(dropDowns, textboxes) {
    //Leave the first row enabled
    for (var i = 1; i < dropDowns.length; i++) {
        var dropDown = dropDowns[i];
        dropDown.disabled = true;

        var textbox = textboxes[i];
        textbox.disabled = true;
    }
}

function getPointsBroughtFromTeamName(teamName) {
    for (var i = 0; i < teamsWithPointsBrought.length; i++) {
        var teamWithPointsBrought = teamsWithPointsBrought[i];
        if (teamWithPointsBrought.Item1 == teamName) {
            return teamWithPointsBrought.Item2;
        }
    }
    return '';
}

function updateCurrentTextboxWithPointsBrought(currentRowIndex, pointsBrought) {
    var idOfCurrentTextbox = "SelectedTeams_X__PointsBrought".replace('X', currentRowIndex);
    var currentTextbox = document.getElementById(idOfCurrentTextbox);
    currentTextbox.value = pointsBrought;
}

function getCurrentRowIndex(currentDropDown) {
    var indexOfUnderscore = currentDropDown.id.indexOf('_')
    var currentRowIndex = currentDropDown.id.substring(indexOfUnderscore + 1, indexOfUnderscore + 2);
    return currentRowIndex;
}

function getNextDropDown(currentId, currentRowIndex, nextRowIndex) {
    var idOfNextDropDown = currentId.replace(currentRowIndex, nextRowIndex);
    var nextDropDown = document.getElementById(idOfNextDropDown);
    return nextDropDown;
}

function getNextTextbox(nextRowIndex) {
    var idOfNextTextbox = "SelectedTeams_X__PointsBrought".replace('X', nextRowIndex);
    var nextTextbox = document.getElementById(idOfNextTextbox);
    return nextTextbox;
}

function enableDisableNextDropDownAndTextbox(currentDropDownValue, nextDropDown, nextTextbox) {
    if (nextTextbox != null) {
        if (currentDropDownValue != '') {
            nextDropDown.disabled = false;
            nextTextbox.disabled = false;
        }
        else if (!nextDropDown.disabled) {
            nextDropDown.selectedIndex = 0;
            nextDropDown.disabled = true;
            nextDropDown.onchange();

            nextTextbox.value = '';
            nextTextbox.disabled = true;
        }
    }
}

function setupEventHandlersForDropDowns(dropDowns, textboxes) {
    for (var i = 0; i < dropDowns.length; i++) {
        dropDowns[i].onchange = function () {
            var teamName = this.options[this.selectedIndex].text;
            var pointsBrought = getPointsBroughtFromTeamName(teamName);
            
            var currentRowIndex = getCurrentRowIndex(this);
            var nextRowIndex = parseInt(currentRowIndex) + 1;
            
            var nextDropDown = getNextDropDown(this.id, currentRowIndex, nextRowIndex);

            updateCurrentTextboxWithPointsBrought(currentRowIndex, pointsBrought);

            var nextTextbox = getNextTextbox(nextRowIndex);

            enableDisableNextDropDownAndTextbox(this.value, nextDropDown, nextTextbox);
        }
    }
}

function disableSubmitButton() {
    var submitButton = document.getElementById('Submit');
    submitButton.setAttribute('disabled', 'disabled');
}

function updateDropDown(teamId) {
    var team1DropDown = document.getElementById('Team1Id');
    var team2DropDown = document.getElementById('Team2Id');
    preventSameTeamSelection(team1DropDown, team2DropDown, teamId);
    enableButtonIfValidState(team1DropDown, team2DropDown);
}

function preventSameTeamSelection(team1DropDown, team2DropDown, teamId) {
    if (team1DropDown.value == team2DropDown.value && team1DropDown.value != defaultValue) {
        if (teamId == 'Team1Id') {
            team2DropDown.value = defaultValue;
        }
        else {
            team1DropDown.value = defaultValue;
        }
    }
}

function enableButtonIfValidState(team1DropDown, team2DropDown) {
    var submitButton = document.getElementById('Submit');
    if (team1DropDown.value != defaultValue && team2DropDown.value != defaultValue) {
        submitButton.removeAttribute('disabled');
    }
    else {
        submitButton.setAttribute('disabled', 'disabled');
    }
}

function callGetPointsBrought(callback) {
    var xmlHttp = new XMLHttpRequest();
    xmlHttp.onreadystatechange = function () {
        if (xmlHttp.readyState == 4 && xmlHttp.status == 200)
            callback(xmlHttp.responseText);
    }
    xmlHttp.open("GET", 'http://localhost:53418/Tournament/GetPointsBrought', true);
    xmlHttp.send(null);
}