﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace IgnasLab
{
    public class SoccerExec
    {
        const string playersPath = "./App_Data/players.txt";
        const string teamsPath = "./App_Data/teams.txt";

        public void Run()
        {
            XList players = InOut.GetPlayers(playersPath);
            List<Team> teams = InOut.GetTeams(teamsPath);

            XList defenders = FilterPlayersByPosition(players, "Defender");
            XList midfields = FilterPlayersByPosition(players, "Midfield");
            XList attackers = FilterPlayersByPosition(players, "Attacker");

            defenders.Sort();
            midfields.Sort();
            attackers.Sort();



        }


        public XList FilterPlayersByPosition(XList list, string position)
        {
            XList filtered = new XList();

            for (list.Begin(); list.Exist(); list.Next())
            {
                if (list.Get().Position.ToLower() == position.ToLower()) filtered.Add(list.Get());
            }
            return filtered;
        }
        public static Table XListToTable(XList list) // Name surname team goals games
        {
            Table table = new Table();

            TableHeaderRow header = new TableHeaderRow();
            header.Cells.Add(new TableHeaderCell() { Text = "Name" });
            header.Cells.Add(new TableHeaderCell() { Text = "Surname" });
            header.Cells.Add(new TableHeaderCell() { Text = "Team" });
            header.Cells.Add(new TableHeaderCell() { Text = "Goals" });
            header.Cells.Add(new TableHeaderCell() { Text = "Games" });

            table.Controls.Add(header);

            for (list.Begin(); list.Exist(); list.Next())
            {
                Player p = list.Get();
                TableRow row = new TableRow();

                row.Cells.Add(new TableCell() { Text = p.Name });
                row.Cells.Add(new TableCell() { Text = p.Surname });
                row.Cells.Add(new TableCell() { Text = p.Team });
                row.Cells.Add(new TableCell() { Text = p.GoalCount.ToString() });
                row.Cells.Add(new TableCell() { Text = p.GameCount.ToString() });

                table.Rows.Add(row);
            }
            return table;
        }

        public static Team FindBestTeam(List<Team> teams)
        {
            Team best;
            int bestPoints = 0;
            if (teams.Count == 0) return null;

            foreach (Team team in teams)
            {
                int teamPoints = team.DrawGameCount + team.WonGameCount * 3; //3 per win, 1 per loss
                if (teamPoints >= bestPoints) best = team;
            }
            return best;
        }

        //Top D, Top M, Top F     3tables                 ------------DONE----------------

        //Find best team                                  ------------DONE----------------

        //Print every best teams player 



    }
}