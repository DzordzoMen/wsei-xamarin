using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AirMonitor.Classes {
    public class DatabaseHelper {
        public DatabaseHelper() {
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            DatabaseConnection = new SQLiteConnection(databasePath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.FullMutex);
            DatabaseConnection.CreateTable<InstallationEntity>();
            DatabaseConnection.CreateTable<MeasurementEntity>();
            DatabaseConnection.CreateTable<MeasurementItemEntity>();
            DatabaseConnection.CreateTable<MeasurementValue>();
            DatabaseConnection.CreateTable<MeasurementIndex>();
        }
        public SQLiteConnection DatabaseConnection { get; set; }

        public void SaveInstallationData(Installation installation) {
            var installationEntity = new InstallationEntity(installation);
            DatabaseConnection.RunInTransaction(() => {
                DatabaseConnection.Insert(installationEntity);
            });
        }

        public void ClearInstallationData() {
            DatabaseConnection.DeleteAll<InstallationEntity>();
        }

        public void ClearMeasurementData() {
            DatabaseConnection.DeleteAll<MeasurementEntity>();
            DatabaseConnection.DeleteAll<MeasurementItemEntity>();
            DatabaseConnection.DeleteAll<MeasurementValue>();
            DatabaseConnection.DeleteAll<MeasurementIndex>();
        }

        public void SaveMeasurementData(Measurement measurement) {
            var measurementEntity = new MeasurementEntity(measurement);
            var measurementItemEntity = new MeasurementItemEntity(measurement.Current);
            DatabaseConnection.RunInTransaction(() => {
                DatabaseConnection.Insert(measurementEntity);
                DatabaseConnection.Insert(measurementItemEntity);
                DatabaseConnection.Insert(measurementEntity.History);
                DatabaseConnection.Insert(measurementEntity.Forecast);
            });
        }

        public IEnumerable<Installation> GetInstallations() {
            return DatabaseConnection.Table<InstallationEntity>().Select(installations => new Installation(installations)).ToList();
        }
    }
}
