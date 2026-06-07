# BeachEquipmentStore — Development Notes

## Planned Work

### Logging
Add structured logging throughout the application as a dedicated implementation pass. This includes:
- Service layer (auth, order, product operations)
- Admin seeder (currently skips silently if AdminEmail/AdminPassword are missing from config)
- Error/exception paths
