const axios = require('axios');

class Roster {
    _baseUrl = 'http://mmilani-001-site1.ftempurl.com';

    constructor(baseUrl) {
        if (baseUrl !== undefined) {
            this._baseUrl = baseUrl;
        }
    }

    get baseUrl() {
        return this._baseUrl;
    }

    set baseUrl(value) {
        this._baseUrl = value;
    }

    apply(membershipApplication) {
        const url = `${this._baseUrl}/roster/apply`;
        return axios.post(url, membershipApplication);
    }

    membershipApplications() {
        const url = `${this._baseUrl}/roster/membership-applications`;
        return axios.get(url).then(response => response.data);
    }

    one(username) {
        const url = `${this._baseUrl}/roster/membership-applications/${username}`;
        return axios.get(url).then(response => response.data);
    }

    accept(username) {
        const url = `${this.baseUrl}/roster/accept/${username}`;
        return axios.post(url);
    }

    clear() {
        const url = `${this.baseUrl}/roster/clear`;
        return axios.post(url);
    }

    delete(username) {
        const url = `${this.baseUrl}/roster/delete/${username}`;
        return axios.delete(url);
    }

    update(membershipApplication) {
        const url = `${this.baseUrl}/roster/update`;
        return axios.patch(url, membershipApplication);
    }
}

module.exports = Roster;