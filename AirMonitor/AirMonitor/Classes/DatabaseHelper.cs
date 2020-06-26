using SQLite;
using System;
using System.IO;

namespace AirMonitor.Classes {
    public class DatabaseHelper {
        public DatabaseHelper() {
            // TODO
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "MyData.db");

            DatabaseConnection = new SQLiteConnection(databasePath);
            DatabaseConnection.CreateTable<InstallationEntity>();
            DatabaseConnection.CreateTable<MeasurementEntity>();
            DatabaseConnection.CreateTable<MeasurementItemEntity>();
            DatabaseConnection.CreateTable<MeasurementValue>();
            DatabaseConnection.CreateTable<MeasurementIndex>();
        }
        public SQLiteConnection DatabaseConnection { get; set; }

        public void SaveInstallationData(Installation installation) {
            var installationEntity = new InstallationEntity(installation);
            DatabaseConnection.Insert(installationEntity);
        }

        public void SaveMeasurementData(Measurement measurement) {
            var measurementEntity = new MeasurementEntity(measurement);
            DatabaseConnection.Insert(measurementEntity);
        }
    }
}
