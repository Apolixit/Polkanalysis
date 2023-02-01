# Roadmap

Substats is an easy to use Substrate ecosystem explorer.  
I have for goal to increase its functionnalities linearly accross time.

This project started in December 2022, after a first proof of concept of Substrate pallet [Money Pot](https://github.com/Apolixit/pallet_money_pot) and the [Blazor Front end](https://github.com/Apolixit/moneypot_blazor)

## Functionnalities

## Schedule

> ### 1st December 2022 - 30 April 2023
>
> - Setup project (see Technical details)
> - Setup basic explorer functionnalities (block / extrinsics / events / accounts / module)
> - Setup Blazor website

| Explorer task      | Description |
| ----------- | ----------- |
| Blocks      | Subscribe to new blocks. Display block details (block number, hash, author, timestamp) |
| Events   | Subscribe to new events. Display event details, module name, event name, parameter details |
| Extrinsics   | Display extrinsic details, module name, call name, timestamps, success or failure, parameter details |
|  |  |
| Account   | Display accout detail, free, lock and reserve balances. All extrinsics and "events" (crowdloan, transfer) linked |
| Validator   | Validator details. Stash, controller and reward account. Nominators who elected him during current era |
| Nominator   | Nominator details. Stash, controller and reward account |
| Pool member   | Display pool information. Name, current active members, rewards |
| ----------- | ----------- |
| Runtime modules   | Display module details. For each module, theirs calls functions, events that can be raised, constants, storage and errors that can be thrown |

| Front app task      | Description |
| ----------- | ----------- |
| Components      | Create shared design components for razor pages. These components are based on free template website and adapt to C# components|

> ### 1st Mai 2023 - 30 July 2023
>
