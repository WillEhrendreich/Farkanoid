module GameEngine.Startup

open GameEngine.Model
open GameEngine.OpenGl
open Silk.NET.Maths
open Silk.NET.Windowing
open System.Numerics

type RenderData =
  { Gl: Silk.NET.OpenGL.GL
    SpriteRenderer: Vector2 -> Vector2 -> Texture.T -> unit
    Scene: Scene
  }


let create windowTitle windowWidth windowHeight sceneDefinition =
  let mutable renderDataOption = None

  let load (window:IWindow) (sceneDefinition:SceneDefinition) _ =
    let gl = Silk.NET.OpenGL.GL.GetApi(window)
    
    let scene = SceneBuilder.createScene gl sceneDefinition
    renderDataOption <- Some
      { Gl = gl
        SpriteRenderer = SpriteRenderer.create gl (float32 window.Size.X) (float32 window.Size.Y)
        Scene = scene
      }
    ()
    
  let updateAndRender (frameTime:double) =
    match renderDataOption with
    | Some rd ->
      rd.Scene.GameObjects
      |> List.iter(fun gameObject ->
        rd.SpriteRenderer gameObject.Position.AsVector2 gameObject.Size.AsVector2 gameObject.Sprite.CurrentTexture
      )        
    | None ->
      () // still loading
  
  let mutable options = WindowOptions.Default
  options.Size <- Vector2D(windowWidth,windowHeight)
  options.Title <- windowTitle
  let window = Window.Create(options)
  window.add_Load (load window sceneDefinition)
  window.add_Render updateAndRender
  window.Run ()
  