﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class CSBackToMahjongHall : SocketPacket
{
	public CSBackToMahjongHall(PACKET_TYPE type)
		:
		base(type)
	{
		fillParams();
		zeroParams();
	}
	protected override void fillParams(){}
}