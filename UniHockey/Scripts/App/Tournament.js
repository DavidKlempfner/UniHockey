function updateDropDown(teamId) {
    var defaultValue = '';

    var team1DropDown = document.getElementById('Team1Id');
    var team2DropDown = document.getElementById('Team2Id');

    if (team1DropDown.value == team2DropDown.value && team1DropDown.value != defaultValue) {
        if (teamId == 'Team1Id') {
            team2DropDown.value = defaultValue;
        }
        else {
            team1DropDown.value = defaultValue;
        }
    }    
}