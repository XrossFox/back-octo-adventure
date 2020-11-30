# Octo-Adventure - .Net Core Back-End

This repo contains the back-end for the game-like project Octo Adventure. This is a Web Rest API in Asp.Net Core.

## Available End-Points:
`GET: => /FieldMatrix/{rows}/{columns}`
This endpoint call receives a GET request with the rows and columns as path parameters. Generates the PlayFieldMatrix and is enclosed in the default Response Wrapper as follows:
``` Json
{
	"message": "Holis :D",
	"body": {
		"fieldGrid": [
			[
				"CUL",
				"UpB",
				"UpB",
				"UpB",
				"CUR"
			],
			[
				"LfB",
				"ST3",
				"ST4",
				"ST1",
				"RgB"
			],
			[
				"LfB",
				"ST3",
				"ST2",
				"ST1",
				"RgB"
			],
			[
				"LfB",
				"ST1",
				"ST4",
				"ST3",
				"RgB"
			],
			[
				"CDL",
				"LwB",
				"LwB",
				"LwB",
				"CDR"
			]
		]
	}
}
```
In which:
- Message: The server message.
- Body: Where the actual data is enclosed
    - fieldGrid: this is the actual matrix that represents the Play Field. It's an array of arrays.

## Setting Up the mapping
The Back-end relies in a json file found in `Config/map.json` file. This file looks like this:
```Json
{
  "CornerUpLeft": "CUL",
  "BorderUpMid": "UpB",
  "CornerUpRight": "CUR",
  "BorderLeft": "LfB",
  "BorderRight": "RgB",
  "CornerDownLeft": "CDL",
  "BorderDownMid": "LwB",
  "CornerDownRight": "CDR",
  "FloorTileSets": {
    "DirtTileSet": {
      "1": "DR1",
      "2": "DR2",
      "3": "DR3",
      "4": "DR4",
      "5": "DR5"
    },
    "StoneTileSet": {
      "1": "ST1",
      "2": "ST2",
      "3": "ST3",
      "4": "ST4",
      "5": "ST5"
    }
  }
}
```
It works as follows:
- For all elements that refer to the borders, including corner tiles: `"<tile-name-back":"<tile-name-front>"`. The `"<tile-name-front>"` should match the tiles as they appear in the front end map.json file. Do not change the ones in the back end side, otherwise, the generate method will not work.
- For tilesets like Dirt and Stone: they are objects that have numbered string keys, since it must comply with the limitation that only key/value pairs are allowed by the .Net Core `Config` API allows. So they look like:
```JSON
"<TileSetName>": {
      "1": "<Front-Name>1",
      "2": "<Front-Name>2",
      "3": "<Front-Name>3",
      "4": "<Front-Name>4",
      "n": "<Front-Name>n"
    }
```
The names for the actual tiles should match those in the front end.

## CORS Issues:
Please note that you might need to add the domain from where you can send requests, otherwise the server condiguration will bounce all your requests. You can add domains in Startup.cs `Startup/Configure()`
```c#
            app.UseCors(options => options.WithOrigins(
                "http://localhost:4200",
                "https://localhost:4200",
                "<add-yout-domain-here>"
                ).AllowAnyMethod());
```