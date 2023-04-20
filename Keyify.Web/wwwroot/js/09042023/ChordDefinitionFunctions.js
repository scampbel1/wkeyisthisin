const textBoxPrototype = {
    htmlFieldName: undefined,
    fieldName: undefined,
    validate: validateTextBox
};

const intervalSelectionPrototype = {
    intervals: [],
    validate: validateIntervalArray
};

const nameTextBox = createNameTextBox();
const intervalsTextBox = createIntervalsTextBox();
const intervalsSelection = createInvervalsSelection();

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
    intervalsTextBox.add = updateIntervalsTextBox;

    return intervalsTextBox;
}

function createInvervalsSelection() {
    var intervalsSelection = Object.create(intervalSelectionPrototype);

    return intervalsSelection;
}

function addInterval(button) {
    let interval = button.innerText;

    intervalsTextBox.add(interval);
    intervalsSelection.intervals.push(interval);

    console.log(intervalsSelection.intervals);
}

function updateIntervalsTextBox(interval) {
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

function submitChordDefinitionProposal() {

    let validationResult = validateFields();

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
    let isIntervalSelectionValid = intervalsSelection.validate();

    if (isNameValid && isIntervalSelectionValid) {
        return true;
    }
    else {
        return false;
    }
}

function clearAll() {
    clearTextbox.call(nameTextBox);
    clearTextbox.call(intervalsTextBox);
    clearIntervalsArray.call(intervalsSelection);
}

function clearIntervalsArray() {
    let intervals = this.intervals;

    if (intervals != null && intervals != undefined && intervals.length > 0) {
        console.log(`Clearing intervals array: ${intervals}`);

        intervals.splice(0, intervals.length);
        console.log(intervals);
    }
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
    if (this.intervals != null && this.intervals.count > 0) {
        console.log("Interval selection valids");

        return true;
    }

    console.warn("Interval selection validation failed.");
    return false;
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