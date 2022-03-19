const Roster = require('./roster');

async function example() {
    const roster = new Roster();

    const membershipApplication = {
        firstName: "John",
        lastName: "Doe",
        username: "jdoe",
        email: "jdoe@gmail.com",
        plainTextPassword: "passwd"
    }

    // clears all applications!!!
    await roster.clear();

    // submit new application
    await roster.apply(membershipApplication);

    // get all applications
    const apps = await roster.membershipApplications();
    console.log(apps);

    // accept application
    await roster.accept(membershipApplication.username);

    // change e-mail and age
    membershipApplication.email = 'newmail@gmail.com';
    membershipApplication.age = 23;
    await roster.update(membershipApplication);

    // store custom data
    const customData = {
        dateOfBirth: '2010/03/01',
        position: 'fullback'
    };

    membershipApplication.flexfield = JSON.stringify(customData);
    await roster.update(membershipApplication);

    // get application
    const lastApp = await roster.one('jdoe');
    console.log('After acceptance >>>', lastApp);

    // delete application
    await roster.delete(membershipApplication.username);
}

example();
