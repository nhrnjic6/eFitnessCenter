# eFitnessCenter
Rest Api + Desktop App + Xamarin App for modern Fitness Center management

When the application starts for the first time it will create new Admin user with following credentials: admin@gmail.com, password12345.
Users can use this account to log in into the desktop application from where they can manage the system.

When client is created, it will have status INACTIVE, until active membership is present for the given user.
INACTIVE clients are not allowed to log in into the system.

All screens follow same rules:
- in order to edit resource, in resource listing, double-click cell of a resource you want to edit.
- this will open edit screen, with pre-filled information
- in order to delete resource, in resource listing, mark entire row, then click delete button
- it is only allowed to mark one row for deletion
- for client membership management, enter client edit screen, and then click membership button
- this will show client membership listing

System supports following operations:
- Clients management
- Trainers management
- Membership management (There will be membership button on edit client screen)
- Suplement/Suplements payment membership
- Workouts/Workout schedules management
- Trainer Advice management
