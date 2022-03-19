# NodeJS client

This is just a short example how to use Roster Membership API.

1. Install package with `npm install @milivojm/roster`.
1. Create a simple node application:

```js
const { Roster, ApplyForMembershipCommand } = require('@milivojm/roster');

async function example() {
    const roster = new Roster();

    const membershipApplication = new ApplyForMembershipCommand('jdoe','passwd','jdoe@gmail.com');
    membershipApplication.firstName = 'John';
    membershipApplication.lastName = 'Doe';
    membershipApplication.age = 30;
    membershipApplication.flexfield = {
        gameProfile: 'johndoe123'
    };

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

    membershipApplication.flexfield = customData;
    await roster.update(membershipApplication);

    // get application
    const lastApp = await roster.one('jdoe');
    console.log('After acceptance >>>', lastApp);

    // delete application
    await roster.delete(membershipApplication.username);
}

example();
```