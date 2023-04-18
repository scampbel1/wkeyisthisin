
const textBoxPrototype = {
    htmlFieldName: undefined,
    fieldName: undefined,
    validate: validateTextBox
};

const nameTextBox = createNameTextBox();
const intervalsTextBox = createIntervalsTextBox();

function createNameTextBox() {
    //Example of "prototypal inheritence" - the "dynamic language version of classical inheritance"
    //See: "You Don't Know JS - this & Object Prototypes" - Page 93.
    let nameTextBox = Object.create(textBoxPrototype);

    nameTextBox.fieldName = "Chord Definition Name";
    nameTextBox.htmlFieldName = "chordDefinitionName";

    return nameTextBox;
}

function createIntervalsTextBox() {
    //Example of "prototypal inheritence" - the "dynamic language version of classical inheritance"
    //See: "You Don't Know JS - this & Object Prototypes" - Page 93.
    let intervalsTextBox = Object.create(textBoxPrototype);

    intervalsTextBox.fieldName = "Chord Definition Intervals";
    intervalsTextBox.htmlFieldName = "chordDefinitionIntervals";
    intervalsTextBox.add = updateIntervals;

    return intervalsTextBox;
}

function addInterval(button) {
    let interval = button.innerText;

    intervalsTextBox.add(interval);
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

function submitChordDefinitionProposal() {

    var validationResult = validateFields();

    if (validationResult) {

        let inserted;
        let errorMessage;

        let proposedName = document.getElementById(nameTextBox.htmlFieldName).value;
        let proposedIntervals = document.getElementById(intervalsTextBox.htmlFieldName).value;

        submitProposal(proposedName, proposedIntervals)
            .then((data) => {
                console.log(data);

                inserted = data.wasInserted;
                errorMessage = data.errorMessage;
            }).then(() => {
                if (inserted == false) {
                    alert(errorMessage);
                }
            });
    }
}

function validateFields() {
    let isNameValid = nameTextBox.validate();
    let isIntervalSelectionValid = intervalsTextBox.validate();

    if (isNameValid && isIntervalSelectionValid) {
        return true;
    }
    else {
        return false;
    }
}

function clearAllTextBoxes() {
    clearTextbox.call(nameTextBox);
    clearTextbox.call(intervalsTextBox);
}

function validateTextBox() {

    let fieldName = this.fieldName;
    let fieldValue = document.getElementById(this.htmlFieldName).value;

    console.log(`${fieldName} - '${fieldValue}'`);

    if (fieldValue == undefined || fieldValue == null || fieldValue == '') {
        let message = `Warning '${fieldValue}' is not a valid value for '${fieldName}'.`;

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

async function submitProposal(name, intervals) {
    let url = `https://${window.location.hostname}:${window.location.port}/ChordDefinition/Submit/`;

    let chordDefinitionRequest = {
        name: name,
        intervals: intervals
    };

    let response = await fetch(url,
        {
            method: 'POST',
            headers:
            {
                'Content-Type': 'application/json'
            },
            body: JSON.stringify(chordDefinitionRequest)
        });

    return response.json();
}