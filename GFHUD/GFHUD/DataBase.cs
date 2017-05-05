using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GFHUD
{
   
    class baseaddress
    {
        public int Player = 0xcbfcec;
        public int Target = 0xcd17d8;
        public int TargetType = 0xcbfe24;
        public int Menus = 0xcd17e8;
        public int Loot = 0xcd1808;
        public int WindowCount = 0xcd3d5c;
        public int Puk1 = 0xcd3e70;
        public int Puk2 = 0xcd3e74;
        public int Puk3 = 0xcd3e78;
        public int Chat = 0xcd3e20;
        public int Zoom = 0xcc046c;
    }
    class offsets
    {
        public int[] PlayerName = { 0x0, 0x120, 0x1c, 0x420 };
        public int[] PlayerHp = { 0x8, 0x8};
        public int[] PlayerHpCap = { 0x8, 0x4c };
        public int[] PlayerMp = { 0x8, 0xc };
        public int[] PlayerMpCap = { 0x8, 0x50 };
        public int[] PlayerLvl = { 0x8, 0x1c };
        public int[] PlayerBuffCount = { 0x8, 0x16c, 0x0, 0x18 };
        public int[] Status = { 0x1c, 0x3c };
        public int[] PlayerAction = { 0x1c, 0x3d };
        public int[] PlayerCombat = { 0x1c, 0x3e };
        public int[] PlayerMoney = { 0x8, 0xf8 };
        public int[] PlayerCoordX = { 0x24 };
        public int[] PlayerCoordY = { 0x28 };
       


    }
}
