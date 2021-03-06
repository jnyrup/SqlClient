// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System;
using Xunit;

namespace Microsoft.Data.SqlClient.ManualTesting.Tests
{
    public class SqlBulkCopyTest
    {
        private string srcConstr = null;
        private string dstConstr = null;
        private static bool IsAzureServer() => DataTestUtility.IsAzureSqlServer(new SqlConnectionStringBuilder((DataTestUtility.TCPConnectionString)).DataSource);
        private static bool AreConnectionStringsSetup() => DataTestUtility.AreConnStringsSetup();

        public SqlBulkCopyTest()
        {
            srcConstr = DataTestUtility.TCPConnectionString;
            dstConstr = (new SqlConnectionStringBuilder(srcConstr) { InitialCatalog = "tempdb" }).ConnectionString;
        }

        public string AddGuid(string stringin)
        {
            stringin += "_" + Guid.NewGuid().ToString().Replace('-', '_');
            return stringin;
        }

        [ConditionalFact(nameof(AreConnectionStringsSetup), nameof(IsAzureServer))]
        public void AzureDistributedTransactionTest()
        {
            AzureDistributedTransaction.Test();
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopyAllFromReaderTest()
        {
            CopyAllFromReader.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_CopyAllFromReader"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopyAllFromReader1Test()
        {
            CopyAllFromReader1.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_CopyAllFromReader1"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopyMultipleReadersTest()
        {
            CopyMultipleReaders.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_CopyMultipleReaders"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopySomeFromReaderTest()
        {
            CopySomeFromReader.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_CopySomeFromReader"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopySomeFromDataTableTest()
        {
            CopySomeFromDataTable.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_CopySomeFromDataTable"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopySomeFromRowArrayTest()
        {
            CopySomeFromRowArray.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_CopySomeFromRowArray"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopyWithEventTest()
        {
            CopyWithEvent.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_CopyWithEvent"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopyWithEvent1Test()
        {
            CopyWithEvent1.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_CopyWithEvent1"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void InvalidAccessFromEventTest()
        {
            InvalidAccessFromEvent.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_InvalidAccessFromEvent"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void Bug84548Test()
        {
            Bug84548.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_Bug84548"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void MissingTargetTableTest()
        {
            MissingTargetTable.Test(srcConstr, dstConstr, AddGuid("@SqlBulkCopyTest_MissingTargetTable"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void MissingTargetColumnTest()
        {
            MissingTargetColumn.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_MissingTargetColumn"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void Bug85007Test()
        {
            Bug85007.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_Bug85007"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CheckConstraintsTest()
        {
            CheckConstraints.Test(dstConstr, AddGuid("SqlBulkCopyTest_Extensionsrc"), AddGuid("SqlBulkCopyTest_Extensiondst"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void TransactionTest()
        {
            Transaction.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_Transaction0"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void Transaction1Test()
        {
            Transaction1.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_Transaction1"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void Transaction2Test()
        {
            Transaction2.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_Transaction2"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void Transaction3Test()
        {
            Transaction3.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_Transaction3"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void Transaction4Test()
        {
            Transaction4.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_Transaction4"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopyVariantsTest()
        {
            CopyVariants.Test(dstConstr, AddGuid("SqlBulkCopyTest_Variants"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void Bug98182Test()
        {
            Bug98182.Test(dstConstr, AddGuid("@SqlBulkCopyTest_Bug98182 "));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void FireTriggerTest()
        {
            FireTrigger.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_FireTrigger"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void ErrorOnRowsMarkedAsDeletedTest()
        {
            ErrorOnRowsMarkedAsDeleted.Test(dstConstr, AddGuid("SqlBulkCopyTest_ErrorOnRowsMarkedAsDeleted"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void SpecialCharacterNamesTest()
        {
            SpecialCharacterNames.Test(srcConstr, dstConstr, AddGuid("@SqlBulkCopyTest_SpecialCharacterNames"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void Bug903514Test()
        {
            Bug903514.Test(dstConstr, AddGuid("SqlBulkCopyTest_Bug903514"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void ColumnCollationTest()
        {
            ColumnCollation.Test(dstConstr, AddGuid("SqlBulkCopyTest_ColumnCollation"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopyAllFromReaderAsyncTest()
        {
            CopyAllFromReaderAsync.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_AsyncTest1")); //Async + Reader
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopySomeFromRowArrayAsyncTest()
        {
            CopySomeFromRowArrayAsync.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_AsyncTest2")); //Async + Some Rows
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopySomeFromDataTableAsyncTest()
        {
            CopySomeFromDataTableAsync.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_AsyncTest3")); //Async + Some Table
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopyWithEventAsyncTest()
        {
            CopyWithEventAsync.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_AsyncTest4")); //Async + Rows + Notification
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void CopyAllFromReaderCancelAsyncTest()
        {
            CopyAllFromReaderCancelAsync.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_AsyncTest5")); //Async + Reader + cancellation token
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void CopyAllFromReaderConnectionClosedAsyncTest()
        {
            CopyAllFromReaderConnectionClosedAsync.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_AsyncTest6")); //Async + Reader + Connection closed
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void CopyAllFromReaderConnectionClosedOnEventAsyncTest()
        {
            CopyAllFromReaderConnectionClosedOnEventAsync.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_AsyncTest7")); //Async + Reader + Connection closed during the event
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void TransactionTestAsyncTest()
        {
            TransactionTestAsync.Test(srcConstr, dstConstr, AddGuid("SqlBulkCopyTest_TransactionTestAsync")); //Async + Transaction rollback
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup), nameof(DataTestUtility.IsNotAzureServer))]
        public void CopyWidenNullInexactNumericsTest()
        {
            CopyWidenNullInexactNumerics.Test(srcConstr, dstConstr);
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void DestinationTableNameWithSpecialCharTest()
        {
            DestinationTableNameWithSpecialChar.Test(srcConstr, AddGuid("SqlBulkCopyTest_DestinationTableNameWithSpecialChar"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void OrderHintTest()
        {
            OrderHint.Test(srcConstr, AddGuid("SqlBulkCopyTest_OrderHint"), AddGuid("SqlBulkCopyTest_OrderHint2"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void OrderHintAsyncTest()
        {
            OrderHintAsync.Test(srcConstr, AddGuid("SqlBulkCopyTest_OrderHintAsync"), AddGuid("SqlBulkCopyTest_OrderHintAsync2"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void OrderHintMissingTargetColumnTest()
        {
            OrderHintMissingTargetColumn.Test(srcConstr, AddGuid("SqlBulkCopyTest_OrderHintMissingTargetColumn"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void OrderHintDuplicateColumnTest()
        {
            OrderHintDuplicateColumn.Test(srcConstr, AddGuid("SqlBulkCopyTest_OrderHintDuplicateColumn"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        public void OrderHintTransactionTest()
        {
            OrderHintTransaction.Test(srcConstr, AddGuid("SqlBulkCopyTest_OrderHintTransaction"));
        }

        [ConditionalFact(typeof(DataTestUtility), nameof(DataTestUtility.AreConnStringsSetup))]
        [ActiveIssue(12219)]
        public void OrderHintIdentityColumnTest()
        {
            OrderHintIdentityColumn.Test(srcConstr, AddGuid("SqlBulkCopyTest_OrderHintIdentityColumn"));
        }
    }
}
