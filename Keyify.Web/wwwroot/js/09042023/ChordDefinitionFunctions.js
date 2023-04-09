//NOTE: This form is to create what is programmatically being created here - C:\Users\cambo\source\repos\scampbel1\wkeyisthisin\Keyify.MusicTheory\Definitions\ChordDefinitions.cs

const chordDefinitionNameFullName = "Chord Definition Name";
const chordDefinitionNameFieldName = "chordDefinitionName";

const intervalFullName = "Chord Definition Intervals";
const intervalFieldName = "chordDefinitionIntervals";

//Example of Implicit Binding. See: "You Don't Know JS - this & Object Prototypes" - Page 14.
var validateNameTextBox = {
    htmlFieldName: chordDefinitionNameFieldName,
    fullName: chordDefinitionNameFullName,
    validate: validateTextbox,
};

//Example of Implicit Binding. See: "You Don't Know JS - this & Object Prototypes" - Page 14.
var validateIntervalTextBox = {
    htmlFieldName: intervalFieldName,
    fullName: intervalFullName,
    validate: validateTextbox,
};

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

    var validationResult = validateFields();

    if (validationResult) {
        //TODO: Implement submit
        alert('Your Chord Definition has been sent!');
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

function clearTextbox() {
    document.getElementById(this.htmlFieldName).value = '';
}

function validateIntervalArray() {
    //Is array null or empty?

    //Does array already exist in database?
    //If so -> show message showing name of existing Chord Template
}