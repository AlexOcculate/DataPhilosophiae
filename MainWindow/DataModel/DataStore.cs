namespace DataPhilosophiae.DataModel
{
   public class DataStore
   {
      [System.ComponentModel.ReadOnly( true )]
      public string Name { get; set; }

      [System.ComponentModel.ReadOnly( false )]
      public bool IsActive { get; set; }

      [System.ComponentModel.ReadOnly( true )]
      public string ConnectionStringName { get; set; }

      [System.ComponentModel.ReadOnly( true )]
      public bool LoadDefaultDatabaseOnly { get; set; }

      [System.ComponentModel.ReadOnly( true )]
      public bool LoadSystemObjects { get; set; }

      [System.ComponentModel.ReadOnly( true )]
      public bool WithFields { get; set; }

      [System.ComponentModel.ReadOnly( true )]
      public bool ValidStagePathDir
      {
         get
         {
            System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( this.StagePathDir );
            return di.Exists;
         }
      }

      [System.ComponentModel.ReadOnly( true )]
      public string StagePathDir { get; set; }

      [System.ComponentModel.ReadOnly( true )]
      [System.ComponentModel.DataAnnotations.Display( AutoGenerateField = false )]
      public string ConnectionString { get; set; }

      [System.ComponentModel.ReadOnly( true )]
      public string ProviderName { get; set; }

      [System.ComponentModel.ReadOnly( true )]
      public bool ValidProviderName
      {
         get
         {
            return !string.IsNullOrWhiteSpace( this.ProviderName );
         }
      }

      private System.IO.FileInfo[ ] _aqbFiles;
      private System.IO.FileInfo _aqbFileMRU;

      [System.ComponentModel.ReadOnly( true )]
      [System.ComponentModel.DataAnnotations.Display( AutoGenerateField = false )]
      public System.IO.FileInfo[ ] AqbFiles
      {
         get
         {
            if( this._aqbFiles == null )
            {
               System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( this.StagePathDir );
               if( di.Exists )
               {
                  this._aqbFiles = di.GetFiles( "*.aqb.config", System.IO.SearchOption.AllDirectories );
               }
            }
            return this._aqbFiles;
         }
      }

      [System.ComponentModel.ReadOnly( true )]
      public int AqbCounter
      {
         get
         {
            return this.AqbFiles != null ? this.AqbFiles.Length : 0;
         }
      }

      [System.ComponentModel.ReadOnly( true )]
      public System.IO.FileInfo AqbFileActive
      {
         get
         {
            if( this._aqbFileMRU != null )
               return this._aqbFileMRU;
            if( this.AqbFiles == null || this.AqbFiles.Length == 0 )
               return null;
            this._aqbFileMRU = this.AqbFiles[ 0 ];
            for( int i = 1; i < this.AqbFiles.Length; i++ )
            {
               if( this._aqbFileMRU.LastWriteTimeUtc < this.AqbFiles[ i ].LastWriteTimeUtc )
               {
                  this._aqbFileMRU = this.AqbFiles[ i ];
               }
            }
            return this._aqbFileMRU;
         }
      }

      private System.IO.FileInfo[ ] _mdiFiles;
      private System.IO.FileInfo _mdiFileMRU;

      [System.ComponentModel.ReadOnly( true )]
      [System.ComponentModel.DataAnnotations.Display( AutoGenerateField = false )]
      public System.IO.FileInfo[ ] MdiFiles
      {
         get
         {
            if( this._mdiFiles == null )
            {
               System.IO.DirectoryInfo di = new System.IO.DirectoryInfo( this.StagePathDir );
               if( di.Exists )
               {
                  this._mdiFiles = di.GetFiles( "*.mdi.config", System.IO.SearchOption.AllDirectories );
               }
            }
            return this._mdiFiles;
         }
      }

      [System.ComponentModel.ReadOnly( true )]
      public int MdiCounter
      {
         get
         {
            return this.MdiFiles != null ? this.MdiFiles.Length : 0;
         }
      }

      [System.ComponentModel.ReadOnly( true )]
      public System.IO.FileInfo MdiFileActive
      {
         get
         {
            if( this._mdiFileMRU != null )
               return this._mdiFileMRU;
            if( this.MdiFiles == null || this.MdiFiles.Length == 0 )
               return null;
            this._mdiFileMRU = this.MdiFiles[ 0 ];
            for( int i = 1; i < this.MdiFiles.Length; i++ )
            {
               if( this._mdiFileMRU.LastWriteTimeUtc < this._mdiFiles[ i ].LastWriteTimeUtc )
               {
                  this._mdiFileMRU = this.MdiFiles[ i ];
               }
            }
            return this._mdiFileMRU;
         }
      }

   }
}
