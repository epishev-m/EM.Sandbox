using EM.Configs;

namespace EM.Game.Editor
{

public sealed class ConfigsValidatorFactory : IConfigsValidatorFactory
{
	public IValidator Create(ILibraryEntryCatalog catalog)
	{
		var validator = new Validator(
			new NullObjectValidator(),
			new StringEmptyValidator(),
			new EnumValidator(),
			new LibraryEntryLinkValidator(catalog),
			new LibraryEntryValidator(catalog));

		return validator;
	}
}

}