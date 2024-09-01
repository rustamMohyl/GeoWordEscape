using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level
{
    public string city;
    public string level;
}

public class Levels 
{
    private List<Level> levels = new List<Level>();

    public Levels() 
    {
        // Level 1
        Level level1 = new Level();
        level1.city = "kyiv";
        level1.level = @"
##########
#        #
#        #
#        #
#        ######################################################
#     y     v                                                 #
#                                                        P    E
#           k                                                 #
#       #######################################################
#       #
#       #
#      i#
#########
";
        levels.Add(level1);

        // Level 2
        Level level2 = new Level();
        level2.city = "paris";
        level2.level = @"
#####################
#                   #
#   ###        ###   #
#   # #        # #   #
#   ###  P     ###   #
#        ###         #
#        # #         #
#     y  ###  E      #
#    k      v        #
######################
";
        levels.Add(level2);

        // Level 3
        Level level3 = new Level();
        level3.city = "new york";
        level3.level = @"
################################
#                              #
#   #######       #######      #
#   #             #     #      #
#   #  P  #       #  E  #      #
#   #######       #######      #
#                              #
#    y        v   k            #
################################
";
        levels.Add(level3);

        // Level 4
        Level level4 = new Level();
        level4.city = "tokyo";
        level4.level = @"
##############################
#          #                 #
#  ####    #   ####   ####    #
#  #  #    ####    ####  #    #
#  #  ######  #    #  ######  #
#  #         # E  #       P   #
#  #########      ########### #
#     y    v    k             #
###############################
";
        levels.Add(level4);

        // Level 5
        Level level5 = new Level();
        level5.city = "sydney";
        level5.level = @"
######################################
#                                    #
#   ##########################       #
#   # P                   #  #       #
#   #######   #######     ####  #######
#          # #       #          #     #
#  ######  # #       #          # E   #
#     y    v  k                    ####
######################################
";
        levels.Add(level5);
    }

    public Level GetLevel(int levelIndex)
    {
        if(levelIndex < 0 || levelIndex >= levels.Count) 
        {
            return levels[0];
        }
        else
        {
            return levels[levelIndex];
        }
    }

    public int Count() {
        return levels.Count;
    }
}

