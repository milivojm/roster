const axios = require('axios');

const membershipApplication = {
    firstName: 'John',
    lastName: 'Doe',
    username: 'jdoe',
    plainTextPassword: 'somepwd',
    email: 'joe.doe@gmail.com'
};

axios.post('http://mmilani-001-site1.ftempurl.com/roster/apply', membershipApplication)
    .then(response => {
        console.log(`Response with ${response.status}.`);
    }).catch(error => {
        console.log('Error', error);
    });