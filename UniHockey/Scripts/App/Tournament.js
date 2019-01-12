var defaultValue = '';

window.onload = setupEventHandlers;

function setupEventHandlers() {
    var team1DropDown = document.getElementById('Team1Id');
    team1DropDown.setAttribute('onchange', "updateDropDown('Team1Id')");

    var team2DropDown = document.getElementById('Team2Id');
    team2DropDown.setAttribute('onchange', "updateDropDown('Team2Id')");
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