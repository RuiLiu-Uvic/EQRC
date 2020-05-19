//
// Copyright (C) 2005 Andras Varga
//
// This program is free software; you can redistribute it and/or
// modify it under the terms of the GNU General Public License
// as published by the Free Software Foundation; either version 2
// of the License, or (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with this program; if not, write to the Free Software
// Foundation, Inc., 59 Temple Place - Suite 330, Boston, MA  02111-1307, USA.
//

package inet.examples.SImulationSep26;

import inet.networklayer.configurator.ipv4.Ipv4NetworkConfigurator;
import inet.node.inet.WirelessHost;
//import inet.node.inet.WirelessHostRui1022;

import inet.node.wireless.AccessPoint;
import inet.physicallayer.ieee80211.packetlevel.Ieee80211ScalarRadioMedium;
import inet.visualizer.contract.IIntegratedVisualizer;

import inet.node.inet.StandardHost;
//import inet.node.inet.StandardHostRui1022;
import inet.node.ethernet.Eth100M;

import inet.node.inet.Router;
import inet.node.internetcloud.InternetCloud;
import ned.DatarateChannel;

import inet.common.misc.ThruputMeter;


network Lan80211acOriginal
{
    parameters:
        int numHosts;
        **.mgmt.numChannels = 2;
    submodules:
        visualizer: <default("IntegratedCanvasVisualizer")> like IIntegratedVisualizer if hasVisualizer() {
            parameters:
                @display("p=100,300;is=s");
        }
        configurator: Ipv4NetworkConfigurator {
            parameters:
                assignDisjunctSubnetAddresses = false;
                @display("p=100,100;is=s");
                //config = xml("<config><interface hosts='*' address='145.236.x.x' netmask='255.255.0.0'/></config>");
        }
        radioMedium: Ieee80211ScalarRadioMedium {
            parameters:
                @display("p=100,200;is=s");
        }
      
        host[numHosts]: WirelessHost {
            @display("r=,,#707070");
           // wlan[*].mgmt.typename = "Ieee80211MgmtStaSimplified";
           // wlan[*].agent.typename = "";
        }
        ap: AccessPoint {
            @display("p=250,200;r=,,#707070");
           // wlan[*].mgmt.typename = "Ieee80211MgmtApSimplified";
           // eth[*]
        }

}

network Lan80211acFinal
{

// this is the codes for experiments in the paper
//    R. Liu, J. Song, Z. Huang and J. Pan, EQRC: An enhanced QR code-based secure e-coupon transaction framework, in: 15 ICC 2019-2019 IEEE International Conference on Communications (ICC), IEEE, 2019, pp. 1–6.
//    and 
//    the paper submitted to JCS.
//   Only for the purpose of academic research. 
    
    parameters:
        int numHosts;
        
        //**.mgmt.numChannels = 2;
    types:
        channel C extends DatarateChannel
        {
            delay = 0 ms;
            datarate = 1000Mbps;
        }
    submodules:
       // ThruputMeter1[numHosts]: ThruputMeter {
       //     parameters:
       //         @display("p=102,202;is=s");
       // }
        visualizer: <default("IntegratedCanvasVisualizer")> like IIntegratedVisualizer if hasVisualizer() {
            parameters:
                @display("p=100,300;is=s");
        }
        configurator: Ipv4NetworkConfigurator {
            parameters:
                @display("p=100,100;is=s");
        }
        radioMedium: Ieee80211ScalarRadioMedium {
            parameters:
                @display("p=100,200;is=s");
        }

        host[numHosts]: WirelessHost {//Rui1022
            parameters:
                @display("r=,,#707070");
                numApps=1;
                app[0].typename="TcpSessionApp";
                app[0].localPort=index;
                
        }
        ap: AccessPoint {
            @display("p=250,200;r=,,#707070");
        }
        server: StandardHost {//Rui1022
            parameters:
                @display("p=204,35");
        }
        
        internet: InternetCloud {
            @display("p=303,69;is=vl");
        }
    connections:
        server.ethg++ <--> C <--> internet.ethg++;
        ap.ethg++ <--> C <--> internet.ethg++;
       // host[numHosts].ethg --> ThruputMeter1[0].in;
      // ThruputMeter1[numHosts].in <--> server.pppg[0];
       //  ap.ethg++ <--> Eth100M <--> wiredHost1.ethg++


}

