using System;
using System.Collections.Generic;

namespace MCSong
{
    public class CmdRedo : Command
    {
        public override string name { get { return "redo"; } }
        public override string[] aliases { get { return new string[] { "" }; } }
        public override CommandType type { get { return CommandType.Building; } }
        public override bool consoleUsable { get { return false; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Guest; } }
        public CmdRedo() { }

        public override void Use(Player p, string message)
        {
            if (message != "") { Help(p); return; }
            byte b;

            p.RedoBuffer.ForEach(delegate(Player.UndoPos Pos)
            {
                Level foundLevel = Level.FindExact(Pos.mapName);
                if (foundLevel != null)
                {
                    b = foundLevel.GetTile(Pos.x, Pos.y, Pos.z);
                    foundLevel.Blockchange(Pos.x, Pos.y, Pos.z, Pos.type);
                    Pos.newtype = Pos.type;
                    Pos.type = b;
                    Pos.timePlaced = DateTime.Now;
                    p.UndoBuffer.Add(Pos);
                }
            });

            Player.SendMessage(p, "Redo performed.");
        }

        public override void Help(Player p)
        {
            Player.SendMessage(p, "/redo - Redoes the Undo you just performed.");
        }
    }
}