module GameEngine.Model

open System.Numerics
open GameEngine.OpenGl
open System.IO

type Size =
  { Width: int ; Height: int }
  member x.AsVector2 = Vector2(float32 x.Width, float32 x.Height)

type Position =
  { X: int ; Y: int }
  member x.AsVector2 = Vector2(float32 x.X, float32 x.Y)  

type Sprite =
  { Textures: Texture.T list
    AnimationSequence: int list
    CurrentFrame: int
  }
  member x.CurrentTexture = x.Textures[x.AnimationSequence[x.CurrentFrame]]
  member x.Size =
    let texture = x.Textures[x.AnimationSequence[x.CurrentFrame]]
    { Width = texture.Width |> int ; Height = texture.Height |> int }
  
type GameObject =
  { Id: string
    Sprite: Sprite
    Position: Position
  }
  member x.Size = x.Sprite.Size
    
type Scene =
  { GameObjects: GameObject list
  }

[<RequireQualifiedAccess>]
type SpriteSource =
  | FromImages of string list
  | FromStrip of image:string*numAcross:int*numDown:int

type SpriteSet =
  static member FromImage (imageName:string) =
    Path.GetFileNameWithoutExtension(imageName), SpriteSource.FromImages [imageName]

type GameObjectDefinition =
  { Id: string
    SpriteSetName: string
    SpriteAnimationSequence: int list
    Position: Position
  }

type SceneDefinition =
  { SpriteSets: (string*SpriteSource) list 
    GameObjects: GameObjectDefinition list    
  }