class ApplyForMembershipCommand {
    constructor(username, plainTextPassword, email) {
        this._username = username;
        this._plainTextPassword = plainTextPassword;
        this._email = email;
    }

    get username() {
        return this._username;
    }

    get plainTextPassword() {
        return this._plainTextPassword;
    }

    get firstName() {
        return this._firstName;
    }

    set firstName(value) {
        this._firstName = value;
    }

    get lastName() {
        return this._lastName;
    }

    set lastName(value) {
        this._lastName = value;
    }

    get phoneNumber() {
        return this._phoneNumber;
    }

    set phoneNumber(value) {
        this._phoneNumber = value;
    }

    get age() {
        return this._age;
    }

    set age(value) {
        this._age = value;
    }

    get flexfield() {
        return this._flexfield;
    }

    set flexfield(value) {
        this._flexfield = JSON.stringify(value);
    }

    toJSON() {
        return {
            username: this._username,
            plainTextPassword: this._plainTextPassword,
            email: this._email,
            firstName: this._firstName,
            lastName: this._lastName,
            phoneNumber: this._phoneNumber,
            age: this._age,
            flexfield: this._flexfield
        };
    }
}

module.exports = ApplyForMembershipCommand;