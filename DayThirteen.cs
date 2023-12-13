﻿namespace AdventOfCode2023;

internal class DayThirteen {
	const string _testSet = "#.##..##.\r\n..#.##.#.\r\n##......#\r\n##......#\r\n..#.##.#.\r\n..##..##.\r\n#.#.##.#.\r\n\r\n#...##..#\r\n#....#..#\r\n..##..###\r\n#####.##.\r\n#####.##.\r\n..##..###\r\n#....#..#";
	const string _dataSet = "#.#.##.##.#\r\n#..#..####.\r\n#.#####..##\r\n#.##..####.\r\n##.#..####.\r\n..#...#..#.\r\n##...#....#\r\n....##....#\r\n##.##.#..#.\r\n#..#.##..##\r\n##.###.##.#\r\n...#.#.##.#\r\n.#.#.#.##.#\r\n##.###.##.#\r\n#..#.##..##\r\n\r\n##.#...#.#.\r\n##.##..#.#.\r\n.#.##......\r\n..######..#\r\n..######..#\r\n.#.##......\r\n##.##..#.#.\r\n##.#...#.#.\r\n...##...#..\r\n...#.###..#\r\n#..#######.\r\n..#.##.###.\r\n..###.##.#.\r\n..##.##.##.\r\n..#.#..##..\r\n\r\n#.....###..###.\r\n.###....#..#...\r\n.#..#.#..##..#.\r\n##.##.#..##..#.\r\n.#....#.#..#.#.\r\n.###.#..#..#..#\r\n#.###..######..\r\n#..#...######..\r\n..#.##.##..##.#\r\n..#.##.##..##.#\r\n#......######..\r\n\r\n.##.#######\r\n.##....##.#\r\n#..#.#.#.##\r\n#####....##\r\n####.....##\r\n#..#.#.#.##\r\n.##....##.#\r\n.##.#######\r\n####.#.###.\r\n#..#####..#\r\n......#####\r\n........###\r\n#..###.###.\r\n\r\n#..##..\r\n#..#...\r\n###.#..\r\n##..###\r\n####.##\r\n..#.#..\r\n..#.###\r\n.##.##.\r\n.##.##.\r\n..#.###\r\n..#.#..\r\n\r\n##.##.#####\r\n#.####.#.##\r\n..#..#....#\r\n#########..\r\n########.##\r\n...##...#.#\r\n.#....#...#\r\n########..#\r\n..####.....\r\n#......###.\r\n#......###.\r\n..####.....\r\n########..#\r\n.#....#...#\r\n...##...#..\r\n########.##\r\n#########..\r\n\r\n...#.#..#....#.\r\n#.##..##.####.#\r\n.##.#.##.#..#.#\r\n#.#.#..##.##.##\r\n..#.######..###\r\n...#.###......#\r\n.##...##......#\r\n##..#.##.####.#\r\n.###......##...\r\n##..#..#..##..#\r\n####.#..##..##.\r\n.###..#.######.\r\n#....##...##...\r\n#.....#...##...\r\n.###..#.######.\r\n\r\n#..####\r\n.##.#..\r\n.##.#.#\r\n#..####\r\n#..####\r\n.##.#.#\r\n.##.#..\r\n#..####\r\n.##...#\r\n#..###.\r\n..###..\r\n\r\n##.##.....#.#\r\n##.##.......#\r\n......#.##...\r\n##.#.#..#.#..\r\n##.#..#######\r\n##...###..#..\r\n##.##.#..#.##\r\n####.#...#..#\r\n###.....####.\r\n...##....#...\r\n...##.#.##.##\r\n....#..#...##\r\n###...#......\r\n\r\n#####.##..#\r\n#.#..######\r\n.#.#...####\r\n.#.#...####\r\n#.#..######\r\n###.#.##..#\r\n...#.######\r\n##.#...####\r\n....#..####\r\n.#.#....##.\r\n.....#.#..#\r\n\r\n.#....#.#..##\r\n.#....#....##\r\n..#..#.......\r\n.##..##...###\r\n##########..#\r\n.#.##.#.###.#\r\n..#..#...#.##\r\n#.####.##..#.\r\n.#....#..##..\r\n#......###.##\r\n.#.##.#..###.\r\n...##...####.\r\n.#....#...#..\r\n##.##.####.##\r\n##....##...##\r\n#.####.####..\r\n###..#####.##\r\n\r\n.##.####....#\r\n.##.#..####.#\r\n#####...#.###\r\n.......#.....\r\n####.#...##..\r\n.##....####.#\r\n.##....######\r\n.##....######\r\n.##....####.#\r\n####.#...##..\r\n.......#.....\r\n#####...#.###\r\n.##.#..####.#\r\n.##.####....#\r\n.###..#...##.\r\n\r\n#####.#.#.#..#.#.\r\n#..###.###.##.###\r\n....#...#..##..#.\r\n#..####..#....#..\r\n#..###..#.####.#.\r\n#####.#.#..##..#.\r\n#####.#.#####.##.\r\n.##..###..####..#\r\n#..#.#..########.\r\n#..##.#####..####\r\n####...#..#..#..#\r\n\r\n########.....\r\n...##.....##.\r\n.........####\r\n#.#..#.#####.\r\n#.#######..#.\r\n#.####.#.#..#\r\n###..#####.#.\r\n#.#..#.#..##.\r\n..####....#.#\r\n..####...#...\r\n#.#..#.#.#..#\r\n#.####.#.....\r\n#.####.#.....\r\n\r\n###....#.##.#.#\r\n..#....#....###\r\n#####.#..#.#.##\r\n##.#.#..##..#..\r\n..###..##...#..\r\n#####.##...####\r\n.....#...##.##.\r\n###....####..##\r\n##.###.##.###..\r\n..##.####.#...#\r\n###.##...#..###\r\n..##.#..##.#...\r\n..##.##.##.#...\r\n###.##...#..###\r\n..##.####.#...#\r\n\r\n.#......#.#######\r\n............####.\r\n....##.....##..##\r\n.###..###........\r\n....##....#..##..\r\n##.#..#.##.######\r\n...####...#######\r\n..######..##.##.#\r\n.########..#.##..\r\n###....#####.##.#\r\n#...##...##......\r\n...#..#...#..##..\r\n##.####.##.......\r\n.##....##.#..##..\r\n#.##..##.#.#.##.#\r\n.#.#..#.#.##.##.#\r\n.##.##.##.##.##.#\r\n\r\n....#.#.#..#.#.\r\n####.#..#.#.#..\r\n#..##.#.#..####\r\n####..###......\r\n....###.#.###..\r\n....#.##....#.#\r\n#..##.###.####.\r\n....##.#...#...\r\n#..#.#.#.#..###\r\n####.#.#...##..\r\n####.#.#...##..\r\n#..#.#.#.#..#.#\r\n....##.#...#...\r\n#..##.###.####.\r\n....#.##....#.#\r\n....###.#.###..\r\n####..###......\r\n\r\n..#####....#####.\r\n##..##########..#\r\n.##.#..####..#.##\r\n..######..######.\r\n..######..######.\r\n.##.#..####..#.##\r\n##..##########..#\r\n..#####....#####.\r\n.....########....\r\n..#..##....##..#.\r\n.###.##.##.##.###\r\n.#.#####..#####.#\r\n..#....#..#.#..#.\r\n\r\n.###.##.###\r\n.###.##.###\r\n####....#.#\r\n#...####...\r\n####....###\r\n.#...##...#\r\n..###..###.\r\n#..#.##.#..\r\n#....##....\r\n\r\n#.#.#.#....#.\r\n###..##.##.##\r\n...##.#....#.\r\n..##.#.####.#\r\n##.#.#.#..#.#\r\n.#..##..##..#\r\n#.#...#....#.\r\n...##.#....#.\r\n...##.#....#.\r\n#.#...#....#.\r\n.#...#..##..#\r\n##.#.#.#..#.#\r\n..##.#.####.#\r\n\r\n#......\r\n.#.####\r\n#.#####\r\n.##...#\r\n..#....\r\n###.##.\r\n##.####\r\n.#..##.\r\n.##....\r\n##..##.\r\n##..##.\r\n\r\n##..#.#..#..###\r\n##.#......#....\r\n####....#.#####\r\n.#.##.##.......\r\n#..#.#..####..#\r\n#..#.#..####..#\r\n.#.##.##.......\r\n\r\n.#..###.#\r\n..#...##.\r\n#####.#.#\r\n....#.###\r\n#.###.#.#\r\n###.####.\r\n##..#..#.\r\n.#.#.....\r\n.#.#.....\r\n##..#..#.\r\n###.####.\r\n#.###.#.#\r\n....#.###\r\n#####...#\r\n..#...##.\r\n.#..###.#\r\n.#..###.#\r\n\r\n#.#.#.....###.##.\r\n#.#.#.....###.##.\r\n#...#.#.#####..#.\r\n..#....#.####....\r\n#.#.##.##..###..#\r\n#.#....#.#.#.####\r\n.##.#####........\r\n.#.#.##..#####..#\r\n.#.......#.######\r\n..##.###.##.#####\r\n####.#..##..#....\r\n##..#.#.##.##.##.\r\n#.#..#.#....##..#\r\n\r\n#...#.####.#.#.##\r\n#..#.#.#..##..#.#\r\n.###...###..#....\r\n####..###.###..##\r\n##..##...###.##..\r\n#.#.##.##..#.#..#\r\n#.#.##.##.##.#..#\r\n.##.#.##...###...\r\n.##.#.##...###...\r\n#.#.##.##.##.#..#\r\n#.#.##.##..#.#..#\r\n\r\n..........##.\r\n.##.#.#.####.\r\n####..###.###\r\n####.#..#..##\r\n.##.##.#...#.\r\n....####...#.\r\n.##...###..##\r\n####.###.#.##\r\n....###.#...#\r\n#..#.##....#.\r\n#..#.##.#..#.\r\n\r\n.###...#.....\r\n.###...#.....\r\n..####.#####.\r\n...#.##.##.##\r\n#.###...###..\r\n####.#.#.###.\r\n#.#.#.##...##\r\n#.#.#.##...##\r\n####.###.###.\r\n#.###...###..\r\n...#.##.##.##\r\n..####.#####.\r\n.###...#.....\r\n\r\n.###..#.#\r\n.#.#..#.#\r\n.#.###..#\r\n##....###\r\n##....###\r\n.#.###..#\r\n.#.#..#.#\r\n.###..#.#\r\n..###.#.#\r\n.##.#.#.#\r\n####..###\r\n###..##.#\r\n#.#.###.#\r\n###..####\r\n#.#.#.#.#\r\n......#..\r\n#..#####.\r\n\r\n#...#..#..###..##\r\n.#.##.#.##.......\r\n.##.#.#...#......\r\n#..#.#...###.##.#\r\n#.#...###.#######\r\n####.##..#...##..\r\n##..#.####.######\r\n..#.#..#.####..##\r\n...######.###..##\r\n####....###......\r\n.#####.#.##..##..\r\n.##..#..#........\r\n####...###...##..\r\n\r\n###.##..#\r\n###.##..#\r\n###.####.\r\n##..#####\r\n#....#..#\r\n#..##.##.\r\n..#..####\r\n\r\n####......#######\r\n####..##..#######\r\n.##.#.##.#.##..##\r\n###...##...######\r\n..##..##..##.....\r\n.#..#....#..#..#.\r\n####..##..#######\r\n#..###..###..##..\r\n.####.##.####..##\r\n.#..........#..#.\r\n#..#..##..#..##..\r\n\r\n....#..#..#..#..#\r\n....#..#..#..#..#\r\n#.#.#.###.#..#.##\r\n..#..###...##...#\r\n.#......##....##.\r\n##..#...#.#..#.#.\r\n#.#######.##.#.##\r\n##...##.#..##..#.\r\n####..#..######..\r\n.##..#..##.##.##.\r\n...#...#..####..#\r\n#####.###......##\r\n.#####.#.######.#\r\n.#.....#.#.##.#.#\r\n.###.......##....\r\n.#...#....#..#...\r\n.#.#..##..#..#..#\r\n\r\n###...###\r\n..#.#.#..\r\n#.#...#.#\r\n###.#.#.#\r\n...##.#..\r\n####..#.#\r\n..#..#..#\r\n###....#.\r\n....#.#..\r\n....#.#..\r\n###....#.\r\n\r\n..#..###.##\r\n##.##.###..\r\n..##....##.\r\n..##..##.##\r\n##..##.####\r\n#####.#....\r\n##.#....###\r\n\r\n.#.#.##.#..\r\n#....#.##..\r\n#.#.###.###\r\n#.##.###.##\r\n.#.##...###\r\n#..........\r\n...##....##\r\n#...#......\r\n###.#.#....\r\n###.#.#....\r\n#...#......\r\n.#.##....##\r\n#..........\r\n.#.##...###\r\n#.##.###.##\r\n\r\n..####...#.####.#\r\n#......##..#..#..\r\n#.#..#.#####..###\r\n##....#####.##.##\r\n..####......##..#\r\n..#..#..#.#.##.#.\r\n#..##..##.######.\r\n..####..###....##\r\n###..#######..###\r\n.#.##.#.#..#..#..\r\n.######.##.#..#.#\r\n\r\n..##..###..\r\n..#####....\r\n...#.#.#.##\r\n...#.#.####\r\n..#####....\r\n..##..###..\r\n##......##.\r\n##.#..#.###\r\n###..##....\r\n...##..##.#\r\n##.###.#.#.\r\n###.#.#....\r\n..##...#..#\r\n####.###.##\r\n....#..#.##\r\n\r\n#....##....\r\n..##....##.\r\n#.##....##.\r\n.#...##...#\r\n#..........\r\n#####..####\r\n#....##....\r\n\r\n..#..#.\r\n##.#.##\r\n#..#...\r\n#...##.\r\n...#...\r\n...#...\r\n#...##.\r\n#..#...\r\n##.#.##\r\n..#..#.\r\n....#..\r\n#.#..##\r\n##....#\r\n...#...\r\n...##..\r\n\r\n.####.####.\r\n.###.......\r\n..#####..##\r\n...#.##..#.\r\n#.#.###..##\r\n.#..##....#\r\n..#....##..\r\n#.#.#.#..#.\r\n#.#.#.#..#.\r\n\r\n...#..####....#..\r\n....#.###...##...\r\n###....#...#.#...\r\n...###...##....##\r\n##.##..#..###.#..\r\n#..#.#...#.#...##\r\n..#....#...#..#..\r\n..#....#...#..#..\r\n#....#...#.#...##\r\n##.##..#..###.#..\r\n...###...##....##\r\n###....#...#.#...\r\n....#.###...##...\r\n...#..####....#..\r\n....#..###.#..###\r\n#.....###....##..\r\n....####....##...\r\n\r\n#.#.#.#..#.#...#.\r\n#..#.#.#..#...###\r\n##.#..#.#.....#.#\r\n###..#..#..#...##\r\n##..#....#...#.#.\r\n.##.#....#...##..\r\n.##......#...##..\r\n##..#....#...#.#.\r\n###..#..#..#...##\r\n##.#..#.#.....#.#\r\n#..#.#.#..#...###\r\n#.#.#.#..#.#...#.\r\n.####...#..##.#..\r\n####.##.#####.##.\r\n.####.#####..#.#.\r\n#...###.......###\r\n#...###.......###\r\n\r\n.#.##.#..##...#\r\n###..###.##.#..\r\n#.####.##..#.##\r\n#.#..#......#..\r\n#.#..#......#..\r\n#.####.##..#.##\r\n###..###.##.#..\r\n\r\n...#.##.##.##.#..\r\n##....######....#\r\n##..#.##..##.#..#\r\n###.#.######.#.##\r\n..#...#.##.#...#.\r\n...#.#.####.#.#..\r\n..###.##..##.###.\r\n....#...##...#...\r\n..#..##....##..#.\r\n.#.#.#..##..#.#.#\r\n##....#.##.#....#\r\n##.#####..#####.#\r\n##....#....#....#\r\n...###.####.###..\r\n..#####....#####.\r\n##...#.####.#...#\r\n########..#######\r\n\r\n####.##...##.##.#\r\n#..##.######..#..\r\n#..##.######.##..\r\n..#.#..##########\r\n.#.#..#.###.##.##\r\n#.#.#..##...###.#\r\n#....#..#.#.#....\r\n#....#..#.#.#....\r\n#.#.#..##...###.#\r\n.#.#..#.###.##.##\r\n..#.#..##########\r\n#..##.######.##..\r\n#..##.######..#..\r\n\r\n##.#..#\r\n######.\r\n.#..#..\r\n.....##\r\n.....##\r\n.#..#..\r\n######.\r\n##.#..#\r\n.###.#.\r\n..#.##.\r\n....##.\r\n.###.#.\r\n##.#..#\r\n\r\n##....###.#..##..\r\n.#...##.##.##..##\r\n#...##.###..#..#.\r\n#..####...#######\r\n#..####.#.#######\r\n#...##.###..#..#.\r\n.#...##.##.##..##\r\n##....###.#..##..\r\n###.#.###..#....#\r\n#...##.#..#..##..\r\n......#..#..#..#.\r\n.#.....##...#..#.\r\n..#...##.##......\r\n\r\n.####.#\r\n...#.##\r\n#...###\r\n#.##...\r\n.##....\r\n....#..\r\n.#..#..\r\n.....##\r\n.##..##\r\n#...###\r\n#...###\r\n\r\n##.#.##\r\n#..#.#.\r\n#.#..##\r\n#.##.##\r\n##..#..\r\n..#.###\r\n.#.####\r\n.#..###\r\n.#..###\r\n\r\n#.##..###.#\r\n...####.##.\r\n.#.###.###.\r\n#.....###..\r\n..####.####\r\n....#..#.##\r\n....#..#.##\r\n..####.####\r\n#.....###..\r\n.#.###.###.\r\n...####.##.\r\n#.##..###.#\r\n#.##..###.#\r\n...####.##.\r\n.#.###.###.\r\n#......##..\r\n..####.####\r\n\r\n.###...#...##\r\n..##.#...#..#\r\n....#.##.####\r\n..#....###.#.\r\n..###.##.####\r\n..####..#...#\r\n..##..#...#..\r\n.......##..##\r\n...#.#.####..\r\n###.#.##.##..\r\n..#.###.#.#.#\r\n####.....#.##\r\n###...#####.#\r\n...#####.####\r\n##.#.#####.##\r\n##.#.#####.##\r\n...#####.####\r\n\r\n#..###.#..##.\r\n.....#.....##\r\n####....####.\r\n....#.....###\r\n#####.##.#.#.\r\n.##..#####.##\r\n.....##..####\r\n#######..#.##\r\n.##..##..#...\r\n#####.#..###.\r\n#..#.###..###\r\n#..#.###..###\r\n#####.##.###.\r\n.##..##..#...\r\n#######..#.##\r\n\r\n..#..##.....#\r\n###.#.##.###.\r\n#.###.#######\r\n####.#..#....\r\n####.#..#....\r\n#.###.#######\r\n###.#.##.###.\r\n..#..##.....#\r\n#.######..##.\r\n.#.##....##..\r\n##.#.....##..\r\n##.#.....##..\r\n.#.##....##..\r\n#.######..###\r\n..#..##.....#\r\n\r\n........####...#.\r\n........####...#.\r\n#...######.##.##.\r\n.####.##.#...##.#\r\n##..###.#......##\r\n#....##.###.#....\r\n#######....#.#.##\r\n.####.#..#.###..#\r\n.####.##...#.##.#\r\n\r\n#####.#.#\r\n#..##.##.\r\n.....#...\r\n#####..#.\r\n.##.....#\r\n....#.###\r\n....#.###\r\n.##.....#\r\n#####..#.\r\n.....#...\r\n#..##.##.\r\n#####.#.#\r\n.##..#...\r\n..#...#..\r\n.##.##..#\r\n....##...\r\n####...#.\r\n\r\n###....\r\n#.###.#\r\n###...#\r\n.#.#.##\r\n###.###\r\n###.###\r\n.#.#.##\r\n###...#\r\n#.###.#\r\n###....\r\n.#####.\r\n#..#...\r\n.####.#\r\n.####.#\r\n#..#..#\r\n.#####.\r\n###....\r\n\r\n......#..####..#.\r\n##..##.#.####.#.#\r\n..##...##....##..\r\n......#..####..#.\r\n#.##.##..#..#..##\r\n##..##.#.####.#.#\r\n.........#####...\r\n.#..#..###..###..\r\n#....###..##..###\r\n#######........##\r\n#########....####\r\n########..##..###\r\n.......##.##.##..\r\n######.##....##.#\r\n......###....###.\r\n......#..####..#.\r\n##..##.#..##..#.#\r\n\r\n..#..####..#.\r\n..#..#..#..#.\r\n##.##....##.#\r\n...########..\r\n###..###...##\r\n##.##....##.#\r\n..#..####..#.\r\n##....##....#\r\n..##########.\r\n##.########.#\r\n...##.##.##..\r\n\r\n..####..####..##.\r\n.###.####.###.##.\r\n##.##....##.##..#\r\n.####....####....\r\n#.#.#.##.#.#..##.\r\n#####.##.########\r\n#...#....#...#..#\r\n\r\n..##..#.##.##.##.\r\n..##..###########\r\n#....#..##.##.##.\r\n.####.##.##..##.#\r\n##..##..########.\r\n######.##..##..##\r\n#....##..#.##.#..\r\n#....###..#..#..#\r\n.....##.##....##.\r\n\r\n.....#...##..####\r\n.....#...#...####\r\n.....#...#...####\r\n.....#...##..####\r\n.#..####...#...#.\r\n#########.##..###\r\n#####.##...##.#.#\r\n..#.#.##.##...##.\r\n....###..##.##.##\r\n#.###..##.#..##.#\r\n.....########..##\r\n##..###.##..#####\r\n.####.#.#..#...##\r\n##..#..#.###.#.#.\r\n#.##...##.#.....#\r\n.#.#.....#.......\r\n#...#####.######.\r\n\r\n#......###.##.#\r\n.##.##.#.#.##.#\r\n######...######\r\n.###.###..####.\r\n###..####..##..\r\n###..####..##..\r\n.###.###..####.\r\n######...######\r\n.##.##...#.##.#\r\n#......###.##.#\r\n#.#####..##..##\r\n\r\n#.##.#.#...\r\n..##..##...\r\n#.##.#.####\r\n.#####.....\r\n#....##..##\r\n..##.......\r\n.####......\r\n#....#.#.##\r\n##..###.#..\r\n.####.#.###\r\n..##..#....\r\n#....#.....\r\n.####.###..\r\n\r\n#..###..#.####..#\r\n#####.##..##..##.\r\n####.#.##....##.#\r\n####....#....#...\r\n.##...#..####..#.\r\n#####..#......#..\r\n#..#.....####....\r\n\r\n#####.#..##.##.\r\n........#......\r\n......##.###...\r\n#####....#..#.#\r\n.##....#######.\r\n####.#..#.##...\r\n.##.#.######.##\r\n....#....###..#\r\n#..#####....##.\r\n.##.##..######.\r\n......#.#.##.#.\r\n####..#..####..\r\n.##...#..##..##\r\n#..##.#.###.#.#\r\n#..###..#..#.##\r\n.##.#..##..#.#.\r\n.##.#...#..#.#.\r\n\r\n.#.#..#.#.##.#.\r\n##########..###\r\n####..####..###\r\n.###..###.##.##\r\n##############.\r\n#.##..##.####.#\r\n##..##..######.\r\n\r\n##..#.####.#.\r\n....#.#..#.#.\r\n....#.#..#.#.\r\n##..#.####.#.\r\n.##.#..##..#.\r\n.#.#.#.##.#.#\r\n#.#.#......#.\r\n#..######.###\r\n..#.##....##.\r\n.#.####..####\r\n....#..##..#.\r\n\r\n....#####....\r\n#######.####.\r\n.#####.##..##\r\n#.##.#..#..#.\r\n#.###.#..####\r\n..#...##.####\r\n.#.#..#.#####\r\n.#.#..#.#####\r\n..#...##.####\r\n#.###....####\r\n#.##.#..#..#.\r\n.#####.##..##\r\n#######.####.\r\n....#####....\r\n....#####....\r\n\r\n.......##\r\n.##..##..\r\n.##..##..\r\n.......##\r\n#....##.#\r\n#..##.#.#\r\n#####...#\r\n####..###\r\n....#.#..\r\n#..#..#.#\r\n........#\r\n#####.###\r\n....#..#.\r\n\r\n#...##.\r\n#....##\r\n#####..\r\n#.###.#\r\n.###..#\r\n.#.#..#\r\n#.###.#\r\n#####..\r\n#....##\r\n#...##.\r\n#...##.\r\n\r\n#.......####..###\r\n.#.#..#.#........\r\n##.#..#.####..###\r\n...####...#....#.\r\n#.#....#.#......#\r\n#...##...#..##..#\r\n##.####.##......#\r\n###....###..##..#\r\n.########.##..##.\r\n\r\n#..#...####\r\n#..##.#####\r\n#..##.#..#.\r\n#..##.#..#.\r\n#..##.#####\r\n#..#...####\r\n##########.\r\n.....#..#..\r\n#..#.#.#.##\r\n#...#.#.##.\r\n#..#.#.###.\r\n....####...\r\n.....#.#..#\r\n.....##.##.\r\n.##.##.##.#\r\n.....######\r\n.##.#..##..\r\n\r\n##.#....#..#.#.\r\n####.##.#...##.\r\n..##..###.##.##\r\n........##..##.\r\n...###.#..#...#\r\n..#.##..#.#####\r\n..####..##.####\r\n...#...##.#.#..\r\n..###.###.#....\r\n##...##.#.#....\r\n###..#.###...##\r\n#####..####.##.\r\n...#...##.#.###\r\n..#....########\r\n...#.#######.##\r\n..##.#.#...##..\r\n..##.#.#...#...\r\n\r\n..#.##.#...\r\n.#.#.......\r\n########.##\r\n..#..###..#\r\n....#..###.\r\n....#..###.\r\n..#..###..#\r\n#######..##\r\n.#.#.......\r\n..#.##.#...\r\n.#.#.#.#.##\r\n.#...#.#.#.\r\n#####.#.##.\r\n##...###..#\r\n##...###..#\r\n\r\n.#.....###.#.....\r\n#.###...#.#......\r\n...#...##....#..#\r\n...#...##....#..#\r\n#.###...#.#......\r\n.#......##.#.....\r\n#.#..########....\r\n..##.##.#####.##.\r\n#...##.#.##.#.##.\r\n#....#..#....#..#\r\n.#.###.##...#####\r\n...##..#.........\r\n.#..####.##.#....\r\n......#.##...####\r\n#..#######..#.##.\r\n\r\n..##...#.#..#.#\r\n...#.#.#......#\r\n.##..###......#\r\n.##..##.#....#.\r\n#.#...##..##..#\r\n#..#..###.##.##\r\n#.##..#.##..##.\r\n####..##......#\r\n#.###.##.####.#\r\n####.#..#....#.\r\n.####..#......#\r\n...##.##.####.#\r\n#.####.#..##..#\r\n.##.####..##..#\r\n..#.####..##..#\r\n\r\n.##..###..#.....#\r\n.##.###.....#.##.\r\n.##.###.....#.##.\r\n.##..#.#..#.....#\r\n.##......###..#.#\r\n#..#.###.###..##.\r\n......####.####.#\r\n#..#.####..#..#..\r\n.##.....##.##.###\r\n\r\n....##...\r\n##.####.#\r\n##..##..#\r\n##.####.#\r\n##......#\r\n####..##.\r\n###.##.##\r\n##......#\r\n###....##\r\n...#..#..\r\n##..##..#\r\n...#..#..\r\n..######.\r\n###....##\r\n##.####.#\r\n...####..\r\n..######.\r\n\r\n.#....#..\r\n.##..##..\r\n.######..\r\n#.#..#.##\r\n#...#..##\r\n#.####.##\r\n#..##..##\r\n.##..##..\r\n.#.##.#..\r\n.#....#..\r\n.##..##..\r\n#.#..#.##\r\n##....###\r\n###..####\r\n.#....#..\r\n\r\n.....#.##.#\r\n........#.#\r\n...###..###\r\n#.#.###.#.#\r\n...#.#....#\r\n..#.##.###.\r\n..###....#.\r\n###.##.###.\r\n###.##.###.\r\n\r\n..###.#..#.###...\r\n..###......###...\r\n#....#....#....##\r\n.#..#.####.#..#..\r\n#.##..#..#..##.##\r\n...#.######.#..##\r\n....##....##.....\r\n...##########....\r\n##..###..###..###\r\n#.#.#......#.#.##\r\n.#.##########.#..\r\n#..###....###..##\r\n..#....##....#...\r\n\r\n.#....##.##..##.#\r\n.#.####.#..##..#.\r\n.#.##..#........#\r\n..##.###..#..#..#\r\n..#...###.#..#.##\r\n#..#...##.####.##\r\n#.#...#.###...##.\r\n##.##..###.##.###\r\n...#.##..........\r\n...#.##..........\r\n##.##..###.##.###\r\n\r\n.###.##.###.#..##\r\n..#.#..#.#...##.#\r\n....#..#.....#.#.\r\n..##....##..#.#.#\r\n..##....##..#.#.#\r\n....#..#.....#.#.\r\n..#.#..#.#...##.#\r\n.###.##.###.##.##\r\n#....##....#####.\r\n.##......##.#.##.\r\n.##......##..###.\r\n.##.#..#.##.###.#\r\n#####..#####.####\r\n...######...#.#.#\r\n#..##..##..##.###\r\n\r\n.....#.....\r\n..#.#.#####\r\n###..##....\r\n##..#.#.##.\r\n..######..#\r\n...#..#....\r\n#####..####\r\n##.#....##.\r\n...#..##..#\r\n####.#..##.\r\n##..##.....\r\n...##.##..#\r\n..###..#..#\r\n#####...##.\r\n......##..#\r\n###...##..#\r\n....#.##.##\r\n\r\n..####.#.#....###\r\n##...##..###.##.#\r\n###.##.#..#....#.\r\n###.##.#..#....#.\r\n##...##..###.##.#\r\n..####.#.#..#.###\r\n.......######.#..\r\n..#.##.....#.....\r\n..#.##.##.#.####.\r\n\r\n##..#.#.###.#\r\n##..#.#.###.#\r\n#.#..###..##.\r\n...#.#...##.#\r\n###.#.##..#.#\r\n.#..####.#.##\r\n.#####.##..#.\r\n.######.#####\r\n#..........#.\r\n#..........#.\r\n.######.#####\r\n.#####.##..#.\r\n.#..####.#.##\r\n###.#.##.##.#\r\n...#.#...##.#\r\n\r\n...##.##.#.####\r\n.#.#...#..#.##.\r\n.#..#..####....\r\n#####.#.#.##..#\r\n.....###.#.#..#\r\n......##.#.#..#\r\n#####.#.#.##..#\r\n\r\n#....######..##\r\n#####.....#.#..\r\n..##..#.#..#.##\r\n..##..##..###..\r\n..##.....##.###\r\n#....###.###.##\r\n##..##.#.#.##..\r\n\r\n##..##.###..###\r\n##..##.###..###\r\n......#.####..#\r\n..##.###.#.####\r\n#....###...#.##\r\n##..####..#.#..\r\n.####.#.....#.#\r\n\r\n###.####.##.#\r\n........#..#.\r\n..####.......\r\n##....##....#\r\n#.#..#.#.##.#\r\n##.##.###..##\r\n##.##.##....#\r\n#.####.#....#\r\n.#.##.#..##..\r\n\r\n####....#.#..###.\r\n.##.#..##...#..##\r\n.##.#..##...#..##\r\n####....#.#..###.\r\n#####.#.#.##.....\r\n..#.....#....###.\r\n#..#.#...##.#..##\r\n#..#####.##...#.#\r\n######.#...#.#...\r\n\r\n.#..#.#...#..\r\n##..##.####..\r\n..##...#..#..\r\n.#..#...#..#.\r\n.####....##..\r\n#....##..####\r\n.####.#.###..\r\n......#.##.##\r\n..##..#...#..\r\n#....#.####..\r\n..##....#####\r\n\r\n#...#.#..##.#\r\n#...#.#..##.#\r\n###..##......\r\n#########...#\r\n.#..#.#.##...\r\n#..####...#..\r\n#..##..#..##.\r\n#....##.....#\r\n#....##.....#\r\n#..##..#..##.\r\n#..####...#..\r\n.#..#...##...\r\n#########...#\r\n###..##......\r\n#...#.#..##.#\r\n\r\n#.#...#\r\n...####\r\n#.#.#..\r\n####...\r\n#....##\r\n##.##..\r\n##.##..\r\n\r\n.##......##..\r\n#..#.....##..\r\n....##...##..\r\n#..#.#...##..\r\n#..##.#.####.\r\n#..#.#...##..\r\n.##...#..##..\r\n#..###.##..##\r\n....##.#....#\r\n....#.....#..\r\n#..#.##.####.\r\n######...##..\r\n####..#.#..#.\r\n....#####..##\r\n.##.#.##....#\r\n#..##.#......\r\n#..#.###....#\r\n\r\n...#....#....#.\r\n#.#......#.#..#\r\n.#...##...#.#..\r\n#.###..###.#...\r\n#.#......#.##.#\r\n##...##...#..#.\r\n.#..#..#..#....\r\n#..........#.#.\r\n.#.#.##.#.#.#..\r\n.#.#.##.#.#.#..\r\n#..........#.#.\r\n\r\n##.####.##.####.#\r\n..#.##.####.##.#.\r\n.#.####.##.####.#\r\n#..#..#....#..#..\r\n#..#..#....#..#..\r\n##.#..#.##.#..#.#\r\n#.##..##..##..##.\r\n####..######..###\r\n###.##.####.##.##\r\n....##......##...\r\n#.##..##..##..##.\r\n#...##......##...\r\n#.##..##..##..##.\r\n\r\n#....#####.##..##\r\n......#..##.#####\r\n########.#.###.##\r\n#.##.###.......##\r\n..##...##..##....\r\n......####.#.####\r\n.......#..###....\r\n####.#.#.###...##\r\n###########..#...\r\n.........#...#.##\r\n......#.#....#...\r\n\r\n.##.##.#.\r\n#.#.##.##\r\n#.......#\r\n#.......#\r\n#.#.##.##\r\n.##.##.#.\r\n.###..###\r\n#..#..##.\r\n.#.####..\r\n####.....\r\n#....#...\r\n....#...#\r\n.####.###\r\n.#...#...\r\n#.#######\r\n#...#..##\r\n#.#.#..##\r\n\r\n.##.#####..\r\n..#.#.##...\r\n###.###.#..\r\n###.##...#.\r\n.#.#...##..\r\n...#...#.#.\r\n##.###....#\r\n##.##.....#\r\n...#...#.#.\r\n.#.#...##..\r\n###.##...#.\r\n###.###.#..\r\n..#.#.##...\r\n.##.#####..\r\n..#......##\r\n##.#.#####.\r\n##.#.#####.";

	public DayThirteen() {
		Console.WriteLine("\n*** Day ***\n");
		Console.WriteLine("" + PartOne(_dataSet));
		Console.WriteLine("" + PartTwo(_dataSet));
	}

	private static long PartOne(string data) {
		return data.Split("\r\n\r\n").Select(pattern => pattern.Split("\r\n")).Select(pattern => GetVerticalLine(pattern) + 100 * GetHorizontalLine(pattern)).Sum();
	}

	private static long GetHorizontalLine(string[] lines) {
		for(int i = 0; i < lines.Length - 1; i++) {
			if(lines[i] == lines[i + 1] && CheckHorizontalSymmetry(i, lines)) {
				return i + 1;
			}
		}

		return 0;
	}

	private static long GetVerticalLine(string[] lines) {
		string current = new(lines.Select(line => line[0]).ToArray());
		string next = "";

		for(int i = 1; i < lines[0].Length; i++) {
			next = new string(lines.Select(line => line[i]).ToArray());

			if(current == next && CheckVerticalSymmetry(i, lines)) {
				return i;
			}

			current = next;
		}

		return 0;
	}

	private static bool CheckHorizontalSymmetry(int idx, string[] lines) {
		int down = idx;
		int up = idx + 1;
		
		while(0 <= down && up < lines.Length) {
			if(lines[down] != lines[up]) {
				return false;
			}

			down--;
			up++;
		}

		return true;
	}

	private static bool CheckVerticalSymmetry(int idx, string[] lines) {
		int down = idx - 1;
		int up = idx;

		while(0 <= down && up < lines[0].Length) {
			if(new string(lines.Select(line => line[down]).ToArray()) != new string(lines.Select(line => line[up]).ToArray())) {
				return false;
			}

			down--;
			up++;
		}

		return true;
	}

	private static long PartTwo(string data) {
		return data.Split("\r\n\r\n").Select(pattern => pattern.Split("\r\n")).Select(pattern => GetVerticalLineWithCorrection(pattern) + 100 * GetHorizontalLineWithCorrection(pattern)).Sum();
	}

	private static long GetHorizontalLineWithCorrection(string[] lines) {
		for(int i = 0; i < lines.Length - 1; i++) {
			Console.WriteLine(lines[i] + " " + lines[i + 1] + " " + GetDiffBetweenStrings(lines[i], lines[i + 1]));
			if((lines[i] == lines[i + 1] || GetDiffBetweenStrings(lines[i], lines[i + 1]) == 1) && CheckHorizontalSymmetryWithCorrection(i, lines)) {
				return i + 1;
			}
		}

		return 0;
	}

	private static long GetVerticalLineWithCorrection(string[] lines) {
		string current = new(lines.Select(line => line[0]).ToArray());
		string next = "";

		for(int i = 1; i < lines[0].Length; i++) {
			next = new string(lines.Select(line => line[i]).ToArray());

			if((current == next || GetDiffBetweenStrings(current, next) == 1) && CheckVerticalSymmetryWithCorrection(i, lines)) {
				return i;
			}

			current = next;
		}

		return 0;
	}

	private static bool CheckHorizontalSymmetryWithCorrection(int idx, string[] lines) {
		int down = idx;
		int up = idx + 1;
		bool usedSmudge = false;

		while(0 <= down && up < lines.Length) {
			if(!usedSmudge && GetDiffBetweenStrings(lines[down], lines[up]) == 1) {
				usedSmudge = true;

				down--;
				up++;

				continue;
			}

			if(lines[down] != lines[up]) {
				return false;
			}

			down--;
			up++;
		}

		return usedSmudge;
	}

	private static bool CheckVerticalSymmetryWithCorrection(int idx, string[] lines) {
		int down = idx - 1;
		int up = idx;
		bool usedSmudge = false;

		while(0 <= down && up < lines[0].Length) {
			string downLine = new(lines.Select(line => line[down]).ToArray());
			string upLine = new(lines.Select(line => line[up]).ToArray());

			if(!usedSmudge && GetDiffBetweenStrings(downLine, upLine) == 1) {
				usedSmudge = true;

				down--;
				up++;

				continue;
			}

			if(downLine != upLine) {
				return false;
			}

			down--;
			up++;
		}

		return usedSmudge;
	}

	private static long GetDiffBetweenStrings(string a, string b) {
		return a.Zip(b, (x, y) => x == y).Count(z => !z);
	}
}

