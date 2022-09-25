*TODOS:* 
1. Mapster or manual mappings? How to map an id to an entity? I can do a partial mapping, and populate the resulting object with objects (dbctx.Set.Find)
2. Are id->entity converters appropriate?
3. Should author DTO have books reference? Since author cannot exist by himself, how do we implement this? Querying books is ok, creating them via DTO is not. Different REST resources?
4. Do I need more controllers? Do I need more actions? (different resources)
5. Fix dependencies, clean. Move to GitHub
6. Downloadable file can have only 1 link to a file, do I need this? Why don't make it store n, since they all will be associated with only one book, and no other book will need to reference them
7. Do I need different handlers for both commands and queries?
8. Tweak models, they're configured very poorly 
9. Validation. Make handlers return Either<DTO, Error>
10. Do I need service registration extension methods?
11. CANT CREATE DB!
![](library.png)