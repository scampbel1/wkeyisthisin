const chordDefinitionNameFullName = "Chord Definition Name";
const chordDefinitionNameFieldName = "chordDefinitionName";

const intervalFullName = "Chord Definition Intervals";
const intervalFieldName = "chordDefinitionIntervals";

function addInterval(button) {
    let interval = button.innerText;

    //Example of Implicit Binding. See: "You Don't Know JS - this & Object Prototypes" - Page 14.
    let intervalTextBox = {
        htmlFieldName: intervalFieldName,
        fullName: intervalFullName,
        add: updateIntervals
    };

    intervalTextBox.add(interval);
}

function updateIntervals(interval) {
    let intervalsFieldName = this.htmlFieldName;

    let intervalsField = document.getElementById(intervalsFieldName);

    let newInterval;

    if (intervalsField.value == '') {
        newInterval = `${interval}`;
    } else {
        newInterval = `-${interval}`;
    }

    intervalsField.value += newInterval;
}

function submitChordDefinition() {

    validateFields();
}

function validateFields() {

    //Example of Implicit Binding. See: "You Don't Know JS - this & Object Prototypes" - Page 14.
    let nameTextbox = {
        htmlFieldName: chordDefinitionNameFieldName,
        fullName: chordDefinitionNameFullName,
        validate: validateTextbox
    };

    //Example of Implicit Binding. See: "You Don't Know JS - this & Object Prototypes" - Page 14.
    let intervalTextBox = {
        htmlFieldName: intervalFieldName,
        fullName: intervalFullName,
        validate: validateTextbox
    };

    let nameValidation = nameTextbox.validate();
    let intervalValidation = intervalTextBox.validate();

    if (nameValidation && intervalValidation) {
        alert('Success!');
    }
}

function validateTextbox() {

    let fullName = this.fullName;
    let fieldValue = document.getElementById(this.htmlFieldName).value;

    console.log(`${fullName} - '${fieldValue}'`);

    if (fieldValue == undefined || fieldValue == null || fieldValue == '') {
        const message = `Warning '${fieldValue}' is not a valid value for ${fullName}.`;

        console.warn(message);
        alert(message);

        return false;
    }
    else {
        //TODO: Search for existing Chord Template name

        //If name exists return false
    }

    return true;
}

function validateIntervalArray() {
    //Is array null or empty?

    //Does array already exist in database?
    //If so -> show message showing name of existing Chord Template
}