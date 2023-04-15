//NOTE: This form is to create what is programmatically being created here - C:\Users\cambo\source\repos\scampbel1\wkeyisthisin\Keyify.MusicTheory\Definitions\ChordDefinitions.cs

const chordDefinitionNameLabel = "Chord Definition Name";
const chordDefinitionNameFieldName = "chordDefinitionName";

const intervalFullNameLabel = "Chord Definition Intervals";
const intervalFieldName = "chordDefinitionIntervals";

//TODO: Convert below to prototype

//Example of Implicit Binding. See: "You Don't Know JS - this & Object Prototypes" - Page 14.
var validateNameTextBox = {
    htmlFieldName: chordDefinitionNameFieldName,
    htmlFieldLabel: chordDefinitionNameLabel,
    validate: validateTextbox
    //findChordDefinition: doesChordDefinitionExist
};

//Example of Implicit Binding. See: "You Don't Know JS - this & Object Prototypes" - Page 14.
var validateIntervalTextBox = {
    htmlFieldName: intervalFieldName,
    htmlFieldLabel: intervalFullNameLabel,
    validate: validateTextbox,
};

function addInterval(button) {
    let interval = button.innerText;

    //Example of Implicit Binding. See: "You Don't Know JS - this & Object Prototypes" - Page 14.
    let intervalTextBox = {
        htmlFieldName: intervalFieldName,
        fullName: intervalFullNameLabel,
        add: updateIntervals
    };

    intervalTextBox.add(interval);
}

function updateIntervals(interval) {
    let intervalsFieldName = this.htmlFieldName;

    var intervalsField = document.getElementById(intervalsFieldName);

    let newInterval;

    if (intervalsField.value == '') {
        newInterval = `${interval}`;
    } else {
        newInterval = `-${interval}`;
    }

    intervalsField.value += newInterval;
}

function submitChordDefinition() {

    var fieldValidationResult = validateFields();

    if (fieldValidationResult) {

        let isFound;
        let chordDefintiionName;

        let userInput = document.getElementById(validateNameTextBox.htmlFieldName).value;

        doesChordDefinitionExist(userInput)
            .then((data) => {
                console.log(data);

                isFound = data.found;
                chordDefinitionName = data.name;

                console.log(isFound);
                console.log(chordDefinitionName);
            });

        let resultWord = isFound ? 'IS' : 'ISN\'T';

        let stupidConfimationMessage = `This is a stupid confimation message to confirm that the Chord Definition ${chordDefintiionName} ${resultWord} already in existence in the Database`;

        alert(stupidConfimationMessage);

        //TODO: Implement submit
        //alert('Your Chord Definition has been sent!');
    }
}

function validateFields() {
    let nameValidation = validateNameTextBox.validate();
    let intervalValidation = validateIntervalTextBox.validate();

    if (nameValidation && intervalValidation) {
        return true;
    }
    else {
        alert('Your Chord Definition request failed!');
        return false;
    }
}

function clearAllTextBoxes() {
    clearTextbox.call(validateNameTextBox);
    clearTextbox.call(validateIntervalTextBox);
}

function validateTextbox() {

    let htmlFieldLabel = this.htmlFieldLabel;
    let fieldValue = document.getElementById(this.htmlFieldName).value;

    console.log(`${htmlFieldLabel} - '${fieldValue}'`);

    if (fieldValue == undefined || fieldValue == null || fieldValue == '') {
        const message = `Warning '${fieldValue}' is not a valid value for ${htmlFieldLabel}.`;

        console.warn(message);
        alert(message);

        return false;
    }

    return true;
}

function clearTextbox() {
    document.getElementById(this.htmlFieldName).value = '';
}

function validateIntervalArray() {
    //Is array null or empty?

    //Does array already exist in database?
    //If so -> show message showing name of existing Chord Template
}

async function doesChordDefinitionExist(proposedChordDefinitionName) {
    let url = `https://${window.location.hostname}:${window.location.port}/ChordTemplate/Find/`;

    //'Accept': 'application/json',
    const response = await fetch(url, {
        credentials: 'same-origin',
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify(proposedChordDefinitionName)
    });

    return response.json();
}