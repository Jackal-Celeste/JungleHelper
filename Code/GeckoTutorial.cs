﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Celeste;
using Celeste.Mod.Entities;
using Microsoft.Xna.Framework;
using Monocle;

namespace Celeste.Mod.JungleHelper {

    [CustomEntity(new string[]
    {
    "JungleHelper/GeckoTutorial"
    })]
    [Tracked(false)]
    public class GeccoTutorialTrigger : Trigger {

        public Gecco gecco;
        public string geckoId;

        public bool ShowTutorial;

        public GeccoTutorialTrigger(EntityData data, Vector2 offset)
            : base(data, offset) {
            geckoId = data.Attr("geckoId");
            ShowTutorial = data.Bool("showTutorial");
        }

        public override void OnEnter(Player player) {
            base.OnEnter(player);
            gecco = Gecco.FindById(player.SceneAs<Level>(),geckoId);
            if (gecco != null) {
                if (ShowTutorial) {
                    gecco.TriggerShowTutorial();
                } else {
                    gecco.TriggerHideTutorial();
                }
            }
        }
    }

}