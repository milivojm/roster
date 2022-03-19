const Roster = require('./roster');

async function example() {
    const roster = new Roster();

    const membershipApplication = {
        username: 'jdoe',
        firstName: 'John',
        lastName: 'Doe',
        plainTextPassword: 'test',
        email: 'jdoe@gmail.com'
    };

    try {
        // clears all applications!!!
        await roster.clear();

        // submit new application
        await roster.submitApplication(membershipApplication);

        // get all applications
        const apps = await roster.membershipApplications();
        console.log(apps);

        // accept application
        await roster.accept(membershipApplication.username);

        // change e-mail and age
        membershipApplication.email = 'newmail@gmail.com';
        membershipApplication.age = 23;
        await roster.update(membershipApplication);

        // get application
        const lastApp = await roster.one('jdoe');
        console.log('After acceptance >>>', lastApp);

        // delete application
        await roster.delete(membershipApplication.username);
    } catch (err) {
        console.log('Error in submitting application.', err);
    }
}

example();
