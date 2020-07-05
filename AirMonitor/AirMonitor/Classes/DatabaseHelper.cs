using SQLite;
using System;
using System.IO;

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
                DatabaseConnection.DeleteAll<InstallationEntity>();
                DatabaseConnection.Insert(installationEntity);
            });
        }

        public void SaveMeasurementData(Measurement measurement) {
            var measurementEntity = new MeasurementEntity(measurement);
            DatabaseConnection.RunInTransaction(() => {
                DatabaseConnection.DeleteAll<MeasurementEntity>();
                DatabaseConnection.DeleteAll<MeasurementItemEntity>();
                DatabaseConnection.DeleteAll<MeasurementValue>();
                DatabaseConnection.DeleteAll<MeasurementIndex>();

                
                DatabaseConnection.Insert(measurementEntity);
            });
        }
    }
}
