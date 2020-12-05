﻿using System;
using System.Numerics;
using Dalamud.Plugin;
using ImGuiNET;

namespace SimpleTweaksPlugin {
    public abstract class Tweak : IDisposable {
        protected SimpleTweaksPlugin Plugin;
        protected DalamudPluginInterface PluginInterface;
        protected SimpleTweaksPluginConfig PluginConfig;

        public virtual bool Ready { get; protected set; }
        public virtual bool Enabled { get; protected set; }

        public abstract string Name { get; }
        public virtual bool Experimental => false;

        public void InterfaceSetup(SimpleTweaksPlugin plugin, DalamudPluginInterface pluginInterface, SimpleTweaksPluginConfig config) {
            this.PluginInterface = pluginInterface;
            this.PluginConfig = config;
            this.Plugin = plugin;
        }

        public virtual bool DrawConfig() {
            ImGui.Indent(56);
            ImGui.Text(Name);
            if (this.Experimental) {
                ImGui.SameLine();
                ImGui.TextColored(new Vector4(1, 0,0,1), "  Experimental");
            }
            ImGui.Indent(-56);
            return false;
        }

        public abstract void Setup();

        public abstract void Enable();

        public abstract void Disable();

        public abstract void Dispose();
    }
}
