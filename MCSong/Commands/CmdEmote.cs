/*
	Copyright 2010 MCSharp team (Modified for use with MCZall/MCSong) Licensed under the
	Educational Community License, Version 2.0 (the "License"); you may
	not use this file except in compliance with the License. You may
	obtain a copy of the License at
	
	http://www.osedu.org/licenses/ECL-2.0
	
	Unless required by applicable law or agreed to in writing,
	software distributed under the License is distributed on an "AS IS"
	BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express
	or implied. See the License for the specific language governing
	permissions and limitations under the License.
*/
using System;

namespace MCSong
{
    public class CmdEmote : Command
    {
        public override string name { get { return "emote"; } }
        public override string[] aliases { get { return new string[] { "<3" }; } }
        public override CommandType type { get { return CommandType.Other; } }
        public override bool consoleUsable { get { return false; } }
        public override bool museumUsable { get { return true; } }
        public override LevelPermission defaultRank { get { return LevelPermission.Banned; } }
        public CmdEmote() { }

        public override void Use(Player p, string message)
        {
            p.parseSmiley = !p.parseSmiley;
            p.smileySaved = false;

            if (p.parseSmiley) Player.SendMessage(p, "Emote parsing is enabled.");
            else Player.SendMessage(p, "Emote parsing is disabled.");
        }
        public override void Help(Player p)
        {
            Player.SendMessage(p, "/emote - Enables or disables emoticon parsing");
        }
    }
}