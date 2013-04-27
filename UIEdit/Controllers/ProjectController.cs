﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Ookii.Dialogs.Wpf;
using UIEdit.Models;

namespace UIEdit.Controllers {
    public class ProjectController {
        public string InterfacesPath { get; set; }
        public string SurfacesPath { get; set; }
        public List<SourceFile> Files { get; set; }

        public void SetLocationInterfaces() {
            var dlg = new VistaFolderBrowserDialog();
            var showDialog = dlg.ShowDialog();
            if (showDialog == null || !((bool) showDialog)) return;
            InterfacesPath = dlg.SelectedPath;
            //InterfacesPath = @"B:\GAMEDEV\PW Interfaces\UIEdit test\interfaces.pck.files\interfaces";
            Files = new List<SourceFile>();
            foreach (var file in Directory.GetFiles(InterfacesPath, "*.xml", SearchOption.AllDirectories).Where(file => File.ReadAllText(file).Contains("﻿<DIALOG "))) {
                Files.Add(new SourceFile { FileName = file, ProjectPath = InterfacesPath});
            }
        }

        public void SetLocationSurfaces() {
            var dlg = new VistaFolderBrowserDialog();
            var showDialog = dlg.ShowDialog();
            if (showDialog == null || !((bool) showDialog)) return;
            //SurfacesPath = @"B:\GAMEDEV\PW Interfaces\UIEdit test\surfaces.pck.files\surfaces";
            SurfacesPath = dlg.SelectedPath;
        }

        public string GetSourceFileContent(SourceFile currentSourceFile) {
            return File.ReadAllText(currentSourceFile.FileName);
        }

        public void SaveSourceFileContent(SourceFile currentSourceFile, string text) {
            File.WriteAllText(currentSourceFile.FileName, text);
        }
    }
}
