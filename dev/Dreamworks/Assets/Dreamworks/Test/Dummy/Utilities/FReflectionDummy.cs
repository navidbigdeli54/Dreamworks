/**Copyright 2016 - 2019, Dream Machine Game Studio. All Right Reserved.*/

using System;

namespace DreamMachineGameStudio.Dreamworks.Test.Dummy.Utility
{
    /// <summary>
    /// A Dummy class that defines TReflectionDummy
    /// </summary>
    /// <Author>Navid Bigdeli</Author>
    /// <CreationDate>January/16/2019</CreationDate>
    [TReflectionDummy(nameof(TReflectionDummy))]
    public class FReflectionDummy
    {
        #region Field
        private string privateField;
        private protected string privateProtectedField;
        protected string protectedField;
        internal protected string internalProtectedField;
        public string publicField;

        private static string privateStaticField;
        private protected static string privateProtectedStaticField;
        protected static string protectedStaticField;
        internal protected static string internalProtectedStaticField;
        public static string publicStaticField;

        private readonly string privateReadOnlyField;
        private protected readonly string privateProtectedReadOnlyField;
        protected readonly string protectedReadOnlyField;
        internal protected readonly string internalProtectedReadOnlyField;
        public readonly string publicReadOnlyField;

        private readonly static string privateReadOnlyStaticField;
        private protected readonly static string privateProtectedReadOnlyStaticField;
        protected readonly static string protectedReadOnlyStaticField;
        internal protected readonly static string internalProtectedReadOnlyStaticField;
        public readonly static string publicReadOnlyStaticField;

        private const string privateConstField = null;
        private protected const string privateProtectedConstField = null;
        protected const string protectedConstField = null;
        internal protected const string internalProtectedConstField = null;
        public const string publicConstField = null;
        #endregion

        #region Property
        private string PrivatePropertyPrivatePrivate { get; set; }

        private protected string PrivateProtectedPropertyPublicPublic { get; set; }
        private protected string PrivateProtectedPropertyPublicPrivate { get; private set; }

        public string PublicPropertyPublicPrivate { get; private set; }
        #endregion
    }
}