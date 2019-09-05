#Naming convention:

## Interface's name should start with  `I`
	ex: ITickable, IInitializable

## Attribute's name should start with `T` without `Attribute` at the end (C# convention is to put `Attribute` at the end of the name, We not going to follow that.)
	ex: TInjectDependency

## CComponent's name should start with `C`
	ex: CObjectPoolManagement

## SScriptableObject's name should start with `S`
	ex: SFrameworkConfiguration

## classes that doesn't inherit from no one name's should start with `F`
	ex: FReflectionUtility

## Do naming private field with lower camel case
	ex: private int fieldName;

## Do naming public members with upper camel case
	ex: public int PropertyName {get; set;}
	ex: public void Method();

## Do naming parameters with lower camel case
	ex: public void Method(int firstParam);

## Do name methods (private or public or protected) upper camel case
	ex: public void Method(int firstParam);

## Do name read-only and constants members entirely upper case and separate words with underscore (`_`)
	ex: private float const PI_NUMBER = 3.14;

## Unit test classes' name should start with `UT_`.
	ex: UT_ServiceLocator